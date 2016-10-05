' Console application portion of namespaces demonstration
' Copyright ©2001 by Desaware Inc. All Rights Reserved
Imports MovingToVB.CH10.Organization.Members
Namespace MovingToVB.CH10.Organization
    Class Organization

    End Class

    Module Module1

        Sub Main()
            Dim org As New Organization()
            ' The following two lines are identical - because of imports
            Dim grp As New CH10.Organization.Members.MemberCollection()
            Dim grp2 As New MemberCollection()

            ' Note, this one is in another assembly!
            ' But is in the same namespace!
            Dim sorter As New CH10.Organization.Members.MemberSorter()
            Dim sorter2 As New MemberSorter()
        End Sub
    End Module
End Namespace

Namespace MovingToVB.CH10.Organization.Members
    Class GroupMember

    End Class
    Class MemberCollection

    End Class
End Namespace


