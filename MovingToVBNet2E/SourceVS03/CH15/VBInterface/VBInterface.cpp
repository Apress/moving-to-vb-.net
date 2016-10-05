/***********************************************************************
   File vbinterface.cpp

   VB Interface demonstration file for Moving to VB.NET: Strategies, Concepts and Code

   Written By Daniel Appleman
   Copyright (c) 1995-2003 by Desaware - All rights reserved

   You have a royalty-free right to use, modify, reproduce and distribute
   this file (and/or any modified version) in any way you find useful,
   provided that you agree that Desaware and Apress have no
   warranty, obligation or liability for its contents, and provided that you change
   the name of file before distributing any modified version of this file.
   
   This file is provided "As-Is". No support is provided for the contents
   or use of this file by Apress, Daniel Appleman or Desaware.

   Refer to the book "Moving To VB.NET: Strategies, Concepts and Code" for further information.
 
 

************************************************************************/

#include "stdafx.h"
#include "stdlib.h"
#include "vbinterface.h"


BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    return TRUE;
}




char tbuf[80];	// Temporary character buffer

STDAPI_(VOID) fToString(double d, char *t)
{
   int x;
   static int decimalvar, signvar;
   char *buffer;
   buffer = _fcvt(d,5,&decimalvar, &signvar);
   if(signvar) *t++ = '-';
   for(x=0; x<decimalvar && *buffer; x++) *t++ = *buffer++;
   if(*buffer) *t++ = '.';
   while(*buffer) *t++ = *buffer++;
   *t = '\0';
}


/* These function demonstrates passing numeric variables by value, and
   returning numeric variables.  The MessageBox statement in each
   routine shows the value of the variable received.
*/

STDAPI_(short) ReceivesShort(short x)
{
	
   _itoa(x, tbuf, 10);   /* Place value in temporary buffer */
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"ReceivesShort", MB_OK);
   return(x);
}

STDAPI_(int) ReceivesInteger(int x)
{
	
   _itoa(x, tbuf, 10);   /* Place value in temporary buffer */
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"ReceivesInteger", MB_OK);
   return(x);
}

STDAPI_(BYTE) ReceivesBytes(BYTE a, BYTE b)
{
	
   tbuf[0] = a;
   tbuf[1] = b;
   tbuf[2] = '\0';
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"ReceivesBytes", MB_OK);
   return('x');
}


STDAPI_(__int64) ReceivesLong(__int64 y)
{
	DumpValues((LPVOID)&y, 8);
    return(y+0x1000200030004000);
}

STDAPI_(float) ReceivesSingle(float f)
{
   fToString((double)f, tbuf);   /* Place value in temporary buffer */
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"ReceivesSingle", MB_OK);
   return(f+1);
}

STDAPI_(double) ReceivesDouble(double d)
{
   fToString(d, tbuf);   /* Place value in temporary buffer */
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"ReceivesDouble", MB_OK);
   return(d+1);
}

/* These functions demonstrate passing numeric variables by reference.
   Note how the DLL function can modify the variable used by VB.
   These particular examples are defined as VOID to be used by SUB
   declarations in VB.  One could just as easily had these return
   results as done in the examples above.
*/

STDAPI_(VOID) Add5ToShort(short FAR *x)
{
   *x = (*x) + 5;
}

STDAPI_(VOID) Add5ToLong(__int64 FAR *y)
{
   *y = (*y) + 5;
}

STDAPI_(VOID) Add5ToSingle(float FAR *f)
{
   *f = (*f) + 5;
}

STDAPI_(VOID) Add5ToDouble(double FAR *d)
{
   *d = (*d) + 5;
}



/* Method used for most API calls.  VB passes a null terminated string
*/
STDAPI_(VOID) ReceivesANSIString(LPSTR tptr)
{
   /* Warning - it's not a copy despite the byval part in the declaration */
   MessageBox(GetFocus(), (LPSTR)tptr, (LPSTR)"ReceivesANSIString", MB_OK);
}

STDAPI_(VOID) ReceivesUnicodeString(LPWSTR tptr)
{
   MessageBoxW(GetFocus(), tptr, L"ReceivesUnicodeString", MB_OK);
}

STDAPI_(VOID) ReceivesAutoString(LPSTR tptr, int count)
{
   DumpValues(tptr, count);
}


/* This example shows how a string can be modified - as long as you don't
   go beyond the space allocated */

STDAPI_(VOID) ChangesStringA(LPSTR tptr)
{
   if (*tptr) *tptr = 'A';
}

STDAPI_(VOID) ChangesStringW(LPWSTR tptr)
{
	if(*tptr) *tptr = 'W';
}


STDAPI_(VOID) ChangesByRefStringW(LPWSTR *ptr)
{
	lstrcpyW(*ptr, L"New String");
}

STDAPI_(VOID) ChangesByRefStringA(LPSTR *ptr)
{
	lstrcpyA(*ptr, "New String");
}

STDAPI_(VOID) ChangesBSTRString(BSTR *sptr)
{
   if(!sptr) return;	// Should never happen - just being paranoid
   if(*sptr) SysFreeString(*sptr);
   *sptr = SysAllocString(L"Any Length Ok");
}


/* This example shows how you can return a string from a DLL. */
STDAPI_(BSTR) ReturnsVBString()
{
   return(SysAllocString(L"Here's a return string"));
}

/* Array of integers - Be careful not to exceed the limit of the array!
   This technique can be used on all numeric data types.
   Note the special calling sequence in the VB example.
   It will not work on strings.
*/

STDAPI_(VOID) ReceivesShortArray(short FAR *iptr)
{
   wsprintf((LPSTR)tbuf, (LPSTR)"1st 4 entries are %d %d %d %d",
            *(iptr), *(iptr+1), *(iptr+2), *(iptr+3));
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"ReceivesShortArray", MB_OK);
   (*iptr)++;	// Increment the int array for to verify the by reference features (that way you
   				// can tell if you are using a temporary copy
   (*(iptr+1))++;
}

short newArrayBuffer[4] = { 5, 4, 3, 2};

STDAPI_(VOID) ReceivesShortRefArray(short FAR **piptr)
{
   short *iptr;
   iptr = *piptr;
	wsprintf((LPSTR)tbuf, (LPSTR)"1st 4 entries are %d %d %d %d",
            *(iptr), *(iptr+1), *(iptr+2), *(iptr+3));
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"ReceivesShortArray", MB_OK);
   (*iptr)++;	// Increment the int array for to verify the by reference features (that way you
   				// can tell if you are using a temporary copy
   (*(iptr+1))++;
   *piptr = newArrayBuffer;
}






STDAPI_(VOID) ReturnsSafeArray(SAFEARRAY **psa)
{
	short *pdata;
	pdata = (short *)((*psa)->pvData);
	wsprintf((LPSTR)tbuf, (LPSTR)"Array of %d dimensions, %ld bytes per element\n First int entry is %d",
   			 (*psa)->cDims, (*psa)->cbElements, *pdata);
            
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"ReturnsArray", MB_OK);
   SAFEARRAYBOUND bounds[1];
   long l;
   bounds[0].lLbound = 0;
   bounds[0].cElements = 4;
   *psa = SafeArrayCreate(VT_I2, 1, bounds);
   short storeval;
   for(l = 0; l<4; l++) {
	storeval = (short)l * 5;
	SafeArrayPutElement(*psa, &l, &storeval);
	}
}
	

	

/* Call by reference only */
STDAPI_(VOID) ReceivesUserType(usertype FAR *u)
{
   DumpValues(u, 30);
	wsprintf((LPSTR)tbuf, (LPSTR)"usertype contains %d %d %d (%d %d %d %d) %s",
            u->a, u->b, u->c, u->d[0], u->d[1], u->d[2], u->d[3], u->e);
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"ReceivesUserType1", MB_OK);
   if(u->c == 3) {
	   lstrcpy(u->e, "New Data");
	   u->d[0] = 99;
	   }
}





STDAPI_(double) UsesDate(double d)
{
   fToString(d, tbuf);   /* Place value in temporary buffer */
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"Date as float", MB_OK);
   return(d+1);
}


STDAPI_(LONG) ShowAddress(LPVOID lp)
{
	wsprintf((LPSTR)tbuf, (LPSTR)"Received address %.8lx", lp);
   MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"ShowAddress", MB_OK);
	return((LONG)lp);
}

STDAPI_(VOID) DumpValues(LPVOID lp, short cnt)
{
	char t2buf[10];
	short x;
	LPBYTE lpb = (LPBYTE)lp;
	tbuf[0] = '\0';
	for (x=0;x<cnt;x++) {
		wsprintf((LPSTR)t2buf,"%.2x ", *(lpb + x));
		lstrcat(tbuf, t2buf);
		}
	MessageBox(GetFocus(), (LPSTR)tbuf, (LPSTR)"Data View", MB_OK);
}



