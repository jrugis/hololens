

Component[] cs = g.GetComponents<Component>();
foreach (Component c in cs)
{
    Debug.Log("@@ " + g.name + "\t[" + c.name + "] " + "\t" + c.GetType() + "\t" + c.GetType().BaseType);
}


