#nullable enable

using System.Collections.Generic;

namespace Kumo
{
    /// <summary>
    ///   Exposes a range, which references a text excerpt
    ///   within a document.
    /// </summary>
    public interface IRange
    {
        /// <summary>The annotation for this <c>IRange</c>.</summary>
        public IAnnotation? Annotation { get; }

        /// <summary>
        ///   <para>Retrieves raw text within this <c>Range</c>.</para>
        ///   <para>
        ///     Note that raw text contains no newlines, therefore
        ///     paragraphs are not separated in any way.
        ///     Use the <c>Paragraphs</c> method to get <c>Range</c>s
        ///     for each paragraph within this <c>Range</c>.
        ///   </para>
        /// </summary>        
        public string Text();

        /// <summary>
        ///     Retrieves a separate <c>Range</c> for
        ///     each paragraph this <c>Range</c> spans.
        /// </summary>
        public IEnumerable<IRange> Paragraphs();

        /// <summary>
        ///     Annotate this <c>IRange</c> using
        ///     the provided <c>IAnnotator</c>.
        /// </summary>
        public void Annotate(IAnnotator annotator);

        /// <summary>Annotate this <c>IRange</c> with <c>property</c>.</summary>
        public IAnnotation Annotate(Property property);

        /// <summary>Annotate this <c>IRange</c> with <c>properties</c>.</summary>
        public IAnnotation Annotate(IEnumerable<Property> properties);

        /// <summary>
        ///     Annotate this <c>IRange</c> replacing its
        ///     current annotation if it exists.
        /// </summary>
        public void Reannotate(object obj);

        /// <summary>
        ///   <para>Checks whether this <c>IRange</c> is valid.</para>
            
        ///   <para>
        ///     A range is considered valid if it spans a sequence
        ///     of neighboring runs. Runs are considered neighbors if they
        ///     are within the same paragraph or directly neighboring
        ///     paragraphs and there are no other runs between them.
        ///   </para>

        ///   <para>For example, the following ranges are not valid:</para>
        ///   <list>
        ///     <item>
        ///       - A range that starts within a main body paragraph
        ///       but ends inside a table paragraph.
        ///     </item>
        ///     <item>
        ///       - A range that spans multiple table cells.
        ///     </item>
        ///   </list>

        ///   <para>Only valid ranges can be annotated.</para>
        /// </summary>
        public bool IsValid();
    }
}
