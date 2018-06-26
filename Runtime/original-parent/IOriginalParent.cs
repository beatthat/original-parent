namespace BeatThat.OriginalParents
{
    /// <summary>
    /// OriginalParent captures the parent of a GameObject so that it can be restored later.
    /// 
    /// Useful for things like a popup that gets transfered to a different parent when it opens
    /// and should be restored to its original parent at the end of use.
    /// </summary>
    public interface IOriginalParent  
	{
		bool didCapture { get; }

		void EnsureCaptured();

		void RestoreOriginalParent();
	}
}
