package md55a24441e35889d1eee1ffeab94363527;


public class EvidenceFragment
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_toString:()Ljava/lang/String;:GetToStringHandler\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("HackAtHomeClient.Fragments.EvidenceFragment, HackAtHomeClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", EvidenceFragment.class, __md_methods);
	}


	public EvidenceFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EvidenceFragment.class)
			mono.android.TypeManager.Activate ("HackAtHomeClient.Fragments.EvidenceFragment, HackAtHomeClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.String toString ()
	{
		return n_toString ();
	}

	private native java.lang.String n_toString ();


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
