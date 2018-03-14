using System;

public class Teacup
{
	TeacupDatabase myData;
	string myString;

	public override string ToString ()
	{
		return myString;
	}

	public Teacup (TeacupDatabase data, string str)
	{
		myData = data;
		if(myData.isValid(str))
			myString = str;
	}
}

