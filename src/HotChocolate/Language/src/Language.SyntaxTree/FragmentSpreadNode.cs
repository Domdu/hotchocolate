using System.Collections.Generic;
using HotChocolate.Language.Utilities;

namespace HotChocolate.Language;

public sealed class FragmentSpreadNode : NamedSyntaxNode, ISelectionNode
{
    public FragmentSpreadNode(
        Location? location,
        NameNode name,
        IReadOnlyList<DirectiveNode> directives)
        : base(location, name, directives)
    { }

    /// <inheritdoc/>
    public override SyntaxKind Kind => SyntaxKind.FragmentSpread;

    /// <inheritdoc/>
    public override IEnumerable<ISyntaxNode> GetNodes()
    {
        yield return Name;

        foreach (DirectiveNode directive in Directives)
        {
            yield return directive;
        }
    }

    /// <summary>
    /// Returns the GraphQL syntax representation of this <see cref="ISyntaxNode"/>.
    /// </summary>
    /// <returns>
    /// Returns the GraphQL syntax representation of this <see cref="ISyntaxNode"/>.
    /// </returns>
    public override string ToString() => SyntaxPrinter.Print(this, true);

    /// <summary>
    /// Returns the GraphQL syntax representation of this <see cref="ISyntaxNode"/>.
    /// </summary>
    /// <param name="indented">
    /// A value that indicates whether the GraphQL output should be formatted,
    /// which includes indenting nested GraphQL tokens, adding
    /// new lines, and adding white space between property names and values.
    /// </param>
    /// <returns>
    /// Returns the GraphQL syntax representation of this <see cref="ISyntaxNode"/>.
    /// </returns>
    public override string ToString(bool indented) => SyntaxPrinter.Print(this, indented);

    public FragmentSpreadNode WithLocation(Location? location) => new(location, Name, Directives);

    public FragmentSpreadNode WithName(NameNode name) => new(Location, name, Directives);

    public FragmentSpreadNode WithDirectives(IReadOnlyList<DirectiveNode> directives)
        => new(Location, Name, directives);
}
