using UnityEngine;

namespace BeatThat.OriginalParents
{
    /// <summary>
    /// OriginalParent captures the parent of a GameObject so that it can be restored later.
    /// 
    /// Useful for things like a popup that gets transfered to a different parent when it opens
    /// and should be restored to its original parent at the end of use.
    /// </summary>
    public class OriginalParent : MonoBehaviour, IOriginalParent
	{
		public bool m_onDisableRestore = true;
		public GameObject m_originalParent;

		public bool didCapture { get; private set; }

		void Start()
		{
			EnsureCaptured();
		}

		void OnDisable()
		{
			Invoke("RestoreOriginalParent", 0); // unity considers it an error to change parent OnDisable so wait one frame
		}

		public void EnsureCaptured()
		{
			if(this.didCapture) {
				return;
			}
			var p = this.transform.parent;
			m_originalParent = (p != null)? p.gameObject: null;
			this.didCapture = true;
		}

		public void RestoreOriginalParent()
		{
			this.transform.SetParent((m_originalParent != null)? m_originalParent.transform: null);
		}
	}
}
