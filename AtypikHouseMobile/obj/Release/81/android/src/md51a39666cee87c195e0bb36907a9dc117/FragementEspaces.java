package md51a39666cee87c195e0bb36907a9dc117;


public class FragementEspaces
	extends android.app.DialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AtypikHouseMobile.Class.FragementEspaces, AtypikHouseMobile", FragementEspaces.class, __md_methods);
	}


	public FragementEspaces ()
	{
		super ();
		if (getClass () == FragementEspaces.class)
			mono.android.TypeManager.Activate ("AtypikHouseMobile.Class.FragementEspaces, AtypikHouseMobile", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
