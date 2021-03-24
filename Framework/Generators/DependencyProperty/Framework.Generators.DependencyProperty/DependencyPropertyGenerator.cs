using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Generators.DependencyProperty
{
	[Generator]
	public class DependencyPropertyGenerator : ISourceGenerator
	{
		/// <summary>
		/// Created on demand before each generation pass
		/// </summary>
		class SyntaxReceiver : ISyntaxContextReceiver
		{
			public List<IFieldSymbol> Fields { get; } = new ();

			/// <summary>
			/// Called for every syntax node in the compilation, we can inspect the nodes and save any information useful for generation
			/// </summary>
			public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
			{
				// any field with at least one attribute is a candidate for property generation
				if (context.Node is FieldDeclarationSyntax fieldDeclarationSyntax
					&& fieldDeclarationSyntax.AttributeLists.Count > 0)
				{
					foreach (var variable in fieldDeclarationSyntax.Declaration.Variables)
					{
						// Get the symbol being declared by the field, and keep it if its annotated
						IFieldSymbol fieldSymbol = context.SemanticModel.GetDeclaredSymbol(variable) as IFieldSymbol;
						if (fieldSymbol.GetAttributes().Any(ad => ad.AttributeClass.ToDisplayString() == "AutoDependencyProperty.AutoDependencyPropertyAttribute"))
						{
							Fields.Add(fieldSymbol);
						}
					}
				}
			}
		}

		private const string AttributeClassNamespace = "AutoDependencyProperty";
		private const string AttributeClassName = "AutoDependencyProperty";

		private const string AttributeClassFullName = AttributeClassNamespace + "." + AttributeClassName;

		private const string attributeText = @"
using System;
namespace AutoDependencyProperty
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    [System.Diagnostics.Conditional(""AutoDependencyPropertyGenerator_DEBUG"")]
    sealed class AutoDependencyPropertyAttribute : Attribute
    {
        public AutoDependencyPropertyAttribute()
        {
        }
        public string PropertyName { get; set; }
    }
}
";
		public void Execute(GeneratorExecutionContext context)
		{
			// retrieve the populated receiver 
			if (context.SyntaxContextReceiver is not SyntaxReceiver receiver)
				return;

			// get the added attribute, and INotifyPropertyChanged
			var attributeSymbol = context.Compilation.GetTypeByMetadataName(AttributeClassFullName);

			// group the fields by class, and generate the source
			foreach (var group in receiver.Fields.GroupBy(f => f.ContainingType))
			{
				string classSource = ProcessClass(group.Key, group.ToList(), attributeSymbol, context);
				context.AddSource($"{group.Key.Name}_autoNotify.cs", SourceText.From(classSource, Encoding.UTF8));
			}
		}

		private string ProcessClass(INamedTypeSymbol classSymbol, List<IFieldSymbol> fields, ISymbol attributeSymbol, GeneratorExecutionContext context)
		{
			if (!classSymbol.ContainingSymbol.Equals(classSymbol.ContainingNamespace, SymbolEqualityComparer.Default))
			{
				return null; //TODO: issue a diagnostic that it must be top level
			}

			string namespaceName = classSymbol.ContainingNamespace.ToDisplayString();

			// begin building the generated source
			StringBuilder source = new StringBuilder($@"
namespace {namespaceName}
{{
    public partial class {classSymbol.Name} 
    {{
");

			// create properties for each field 
			foreach (IFieldSymbol fieldSymbol in fields)
			{
				ProcessField(source, fieldSymbol, attributeSymbol);
			}

			source.Append("} }");
			return source.ToString();
		}

		private void ProcessField(StringBuilder source, IFieldSymbol fieldSymbol, ISymbol attributeSymbol)
		{
			// get the name and type of the field
			string fieldName = fieldSymbol.Name;
			ITypeSymbol fieldType = fieldSymbol.Type;

			// get the AutoNotify attribute from the field, and any associated data
			AttributeData attributeData = fieldSymbol.GetAttributes().Single(ad => ad.AttributeClass.Equals(attributeSymbol, SymbolEqualityComparer.Default));
			TypedConstant overridenNameOpt = attributeData.NamedArguments.SingleOrDefault(kvp => kvp.Key == "PropertyName").Value;

			string propertyName = chooseName(fieldName, overridenNameOpt);
			if (propertyName.Length == 0 || propertyName == fieldName)
			{
				//TODO: issue a diagnostic that we can't process this field
				return;
			}
			/*
			source.Append($@"
public {fieldType} {propertyName} 
{{
    get 
    {{
        return this.{fieldName};
    }}
    set
    {{
        this.{fieldName} = value;
        this.PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof({propertyName})));
    }}
}}
");
			*/
			string chooseName(string fieldName, TypedConstant overridenNameOpt)
			{
				if (!overridenNameOpt.IsNull)
				{
					return overridenNameOpt.Value.ToString();
				}

				fieldName = fieldName.TrimStart('_');
				if (fieldName.Length == 0)
					return string.Empty;

				if (fieldName.Length == 1)
					return fieldName.ToUpper();

				return fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1);
			}

		}

		public void Initialize(GeneratorInitializationContext context)
		{
			// Register the attribute source
			context.RegisterForPostInitialization((i) => i.AddSource("AutoNotifyAttribute", attributeText));

			// Register a syntax receiver that will be created for each generation pass
			context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
		}
	}
}
