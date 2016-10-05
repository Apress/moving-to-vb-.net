#include "oleauto.h"

typedef struct usertypestruct {
   BYTE a;	// Matches VB integer type
   short b;
   long c;
   BYTE d[4];
   char e[16];
} usertype;



STDAPI_(short) ReceivesShort(short x);
STDAPI_(int) ReceivesInteger(int x);
STDAPI_(BYTE) ReceivesBytes(BYTE a, BYTE b);
STDAPI_(__int64) ReceivesLong(__int64 y);
STDAPI_(float) ReceivesSingle(float f);
STDAPI_(double) ReceivesDouble(double d);
STDAPI_(VOID) Add5ToShort(short FAR *x);
STDAPI_(VOID) Add5ToLong(__int64 FAR *y);
STDAPI_(VOID) Add5ToSingle(float FAR *f);
STDAPI_(VOID) Add5ToDouble(double FAR *d);

STDAPI_(VOID) ReceivesANSIString(LPSTR tptr);
STDAPI_(VOID) ReceivesUnicodeString(LPWSTR tptr);
STDAPI_(VOID) ReceivesAutoString(LPSTR tptr, int count);

STDAPI_(VOID) ChangesStringA(LPSTR tptr);
STDAPI_(VOID) ChangesStringW(LPWSTR tptr);

STDAPI_(VOID) ChangesByRefStringW(LPWSTR *ptr);
STDAPI_(VOID) ChangesByRefStringA(LPSTR *ptr);


STDAPI_(VOID) ChangesBSTRString(BSTR *sptr);
STDAPI_(BSTR) ReturnsVBString();
STDAPI_(VOID) ReceivesShortArray(short FAR *iptr);
STDAPI_(VOID) ReceivesShortRefArray(short FAR **iptr);
STDAPI_(VOID) ReturnsSafeArray(SAFEARRAY **);

STDAPI_(VOID) ReceivesUserType(usertype FAR *u);



STDAPI_(VOID) AddUserString(usertype FAR *u);
STDAPI_(usertype) ReturnUserType();



STDAPI_(LONG) ShowAddress(LPVOID lp);
STDAPI_(VOID) DumpValues(LPVOID lp, short cnt);

