
//  Microsoft (R) .NET Framework IL Disassembler.  Version 1.0.2728.0
//  Copyright (C) Microsoft Corp. 1998-2001. All rights reserved.

// VTableFixup Directory:
// No data.
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:2411:0
}
.assembly extern Microsoft.VisualBasic
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 7:0:9185:0
}
.assembly extern System
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:2411:0
}
.assembly extern System.Data
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:2411:0
}
.assembly extern System.Xml
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:2411:0
}
.assembly extern strongDLL1
{
  .publickeytoken = (41 39 A2 C4 51 EF 76 D7 )                         // A9..Q.v.
  .ver 1:0:0:1
}
.assembly StrongApp1
{
  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(bool,
  //                                                                                bool) = ( 01 00 01 01 00 00 ) 
  .custom instance void [mscorlib]System.CLSCompliantAttribute::.ctor(bool) = ( 01 00 01 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 21 43 6F 70 79 72 69 67 68 74 20 C2 A9 32   // ..!Copyright ..2
                                                                                                  30 30 31 20 62 79 20 44 65 73 61 77 61 72 65 20   // 001 by Desaware 
                                                                                                  49 6E 63 2E 00 00 )                               // Inc...
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 10 4D 6F 76 69 6E 67 20 74 6F 20 56 42 2E   // ...Moving to VB.
                                                                                                4E 45 54 00 00 )                                  // NET..
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 0D 44 65 73 61 77 61 72 65 20 49 6E 63 2E   // ...Desaware Inc.
                                                                                                00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 1B 45 78 61 6D 70 6C 65 20 6F 66 20 73 74   // ...Example of st
                                                                                                    72 6F 6E 67 20 6E 61 6D 65 64 20 61 70 70 00 00 ) // rong named app..
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 0A 53 74 72 6F 6E 67 41 70 70 31 00 00 )    // ...StrongApp1..
  .custom instance void [mscorlib]System.Reflection.AssemblyKeyFileAttribute::.ctor(string) = ( 01 00 2C 44 3A 5C 43 50 42 6B 6E 65 74 5C 53 72   // ..,D:\CPBknet\Sr
                                                                                                63 31 5C 43 48 31 36 5C 53 74 72 6F 6E 67 41 70   // c1\CH16\StrongAp
                                                                                                70 31 5C 74 65 73 74 6B 65 79 73 2E 73 6E 6B )    // p1\testkeys.snk
  .publickey = (00 24 00 00 04 80 00 00 94 00 00 00 06 02 00 00   // .$..............
                00 24 00 00 52 53 41 31 00 04 00 00 01 00 01 00   // .$..RSA1........
                79 8C 77 3C C5 93 53 C8 90 95 22 9B 4E 58 69 0A   // y.w<..S...".NXi.
                3B 1F 93 3E B1 46 95 CD 77 59 E3 08 FE 4B FB D4   // ;..>.F..wY...K..
                AC 33 92 55 18 01 6F A5 9A 76 F3 63 C6 A9 8D 9A   // .3.U..o..v.c....
                A2 BE 66 BE 49 56 A4 DF 42 D4 FB 50 D5 22 5F EB   // ..f.IV..B..P."_.
                33 62 D9 36 A9 2F A3 0C F9 AA 61 6A C1 2C 79 46   // 3b.6./....aj.,yF
                61 21 AF 1E 60 D0 72 6C D5 2E A6 4E 2F 4A DF 82   // a!..`.rl...N/J..
                A1 40 23 FF FE EC 8D BB 7A 52 97 98 83 59 16 6E   // .@#.....zR...Y.n
                86 47 C4 E9 16 85 78 7C 4D 10 36 20 46 32 16 BF ) // .G....x|M.6 F2..
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module StrongApp1.exe
// MVID: {E886D843-2040-4E81-997F-5C0194F9851E}
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000009
// Image base: 0x03af0000
.namespace StrongApp1
{
  .class private auto ansi sealed Module1
         extends [mscorlib]System.Object
  {
    .custom instance void [Microsoft.VisualBasic]Microsoft.VisualBasic.Globals/StandardModuleAttribute::.ctor() = ( 01 00 00 00 ) 
    .method public static void  Main() cil managed
    {
      .entrypoint
      // Code size       27 (0x1b)
      .maxstack  1
      .locals init ([0] class [strongDLL1]strongDLL1.Class1 c)
      IL_0000:  nop
      IL_0001:  newobj     instance void [strongDLL1]strongDLL1.Class1::.ctor()
      IL_0006:  stloc.0
      IL_0007:  ldloc.0
      IL_0008:  callvirt   instance string [strongDLL1]strongDLL1.Class1::MyVersion()
      IL_000d:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_0012:  nop
      IL_0013:  call       string [mscorlib]System.Console::ReadLine()
      IL_0018:  pop
      IL_0019:  nop
      IL_001a:  ret
    } // end of method Module1::Main

  } // end of class Module1

} // end of namespace StrongApp1

//*********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file D:\CPBknet\Src1\CH16\StrongApp1\strongapp1.res
