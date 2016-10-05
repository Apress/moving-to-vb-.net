// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

#using <mscorlib.dll>

using namespace System;

// This is the entry point for this application
#ifdef _UNICODE
int wmain(void)
#else
int main(void)
#endif
{
	short counter;

	short x;
	x = 50;  // Variable not defined at this point
    for(counter = 1;counter<=3;counter++) {
        if (true) {
			short x;	// C# requires initialization
			Console::WriteLine(x);	
			x= counter;
			}
		}
	Console::WriteLine(x.ToString());
	Console::ReadLine();
    return 0;

}