package md555bf90f58ef3717ef15832df999217f6;


public class ModifierProfil
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AtypikHouseMobile.ModifierProfil, AtypikHouseMobile", ModifierProfil.class, __md_methods);
	}


	public ModifierProfil ()
	{
		super ();
		if (getClass () == ModifierProfil.class)
			mono.android.TypeManager.Activate ("AtypikHouseMobile.ModifierProfil, AtypikHouseMobile", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
