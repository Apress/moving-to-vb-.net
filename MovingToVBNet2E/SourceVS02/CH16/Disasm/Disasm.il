
//  Microsoft (R) .NET Framework IL Disassembler.  Version 1.0.3427.0
//  Copyright (C) Microsoft Corporation 1998-2001. All rights reserved.

.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:3300:0
}
.assembly extern Microsoft.VisualBasic
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 7:0:3300:0
}
.assembly extern System
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:3300:0
}
.assembly extern System.Data
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:3300:0
}
.assembly extern System.Xml
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:3300:0
}
.assembly Disasm
{
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 01 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 1A 43 6F 70 79 72 69 67 68 74 2C 20 53 75   // ...Copyright, Su
                                                                                                  70 65 72 44 6F 74 43 6F 6D 2E 43 4F 4D 00 00 )    // perDotCom.COM..
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 0D 53 75 70 65 72 20 45 6D 61 69 6C 65 72   // ...Super Emailer
                                                                                                00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 0F 53 75 70 65 72 44 6F 74 43 6F 6D 2E 43   // ...SuperDotCom.C
                                                                                                4F 4D 00 00 )                                     // OM..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 17 4F 75 72 20 73 75 70 65 72 20 45 6D 61   // ...Our super Ema
                                                                                                    69 6C 20 70 72 6F 67 72 61 6D 00 00 )             // il program..
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 06 44 69 73 61 73 6D 00 00 )                // ...Disasm..
  .hash algorithm 0x00008004
  .ver 1:0:692:38537
}
.module Disasm.dll
// MVID: {9DA8ADF2-7D8F-42E8-AD0F-D66F1943688E}
.imagebase 0x00400000
.subsystem 0x00000002
.file alignment 512
.corflags 0x00000001
// Image base: 0x03eb0000
//
// ============== CLASS STRUCTURE DECLARATION ==================
//
.namespace Disasm
{
  .class public auto ansi Emailer
         extends [mscorlib]System.Object
  {
  } // end of class Emailer

} // end of namespace Disasm


// =============================================================


// =============== GLOBAL FIELDS AND METHODS ===================


// =============================================================


// =============== CLASS MEMBERS DECLARATION ===================
//   note that class flags, 'extends' and 'implements' clauses
//          are provided here for information only

.namespace Disasm
{
  .class public auto ansi Emailer
         extends [mscorlib]System.Object
  {
    .method public specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ret
    } // end of method Emailer::.ctor

    .method public instance bool  VerifyEmail(string Email) cil managed
    {
      // Code size       21 (0x15)
      .maxstack  3
      .locals init (bool V_0)
      IL_0000:  ldarg.1
      IL_0001:  ldstr      "@"
      IL_0006:  ldc.i4.0
      IL_0007:  call       int32 [Microsoft.VisualBasic]Microsoft.VisualBasic.Strings::InStr(string,
                                                                                             string,
                                                                                             valuetype [Microsoft.VisualBasic]Microsoft.VisualBasic.CompareMethod)
      IL_000c:  ldc.i4.0
      IL_000d:  ble.s      IL_0013

      IL_000f:  ldc.i4.1
      IL_0010:  stloc.0
      IL_0011:  br.s       IL_0013

      IL_0013:  ldloc.0
      IL_0014:  ret
    } // end of method Emailer::VerifyEmail

    .method public instance string  GetMyHost() cil managed
    {
      // Code size       17 (0x11)
      .maxstack  1
      .locals init (string V_0)
      IL_0000:  ldarg.0
      IL_0001:  callvirt   instance int32 Disasm.Emailer::Delay()
      IL_0006:  pop
      IL_0007:  call       string [System]System.Net.Dns::GetHostName()
      IL_000c:  stloc.0
      IL_000d:  br.s       IL_000f

      IL_000f:  ldloc.0
      IL_0010:  ret
    } // end of method Emailer::GetMyHost

    .method private instance int32  Delay() cil managed
    {
      // Code size       48 (0x30)
      .maxstack  2
      .locals init (int32 V_0,
               int64 V_1,
               int64 V_2)
      IL_0000:  ldc.i8     0x1
      IL_0009:  stloc.1
      IL_000a:  ldloc.2
      IL_000b:  ldc.i8     0x1
      IL_0014:  add.ovf
      IL_0015:  stloc.2
      IL_0016:  ldloc.1
      IL_0017:  ldc.i8     0x1
      IL_0020:  add.ovf
      IL_0021:  stloc.1
      IL_0022:  ldloc.1
      IL_0023:  ldc.i8     0xf4240
      IL_002c:  ble.s      IL_000a

      IL_002e:  ldloc.0
      IL_002f:  ret
    } // end of method Emailer::Delay

  } // end of class Emailer


// =============================================================

} // end of namespace Disasm

//*********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file E:\MovingToVBNet\Source\CH16\Disasm\Disasm.res
