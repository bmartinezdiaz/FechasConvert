Imports System.Xml
'modulo ParsingUsingXmlDocument
imports System.IO

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = DateTime.Parse(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            'Creamos el "Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load(TextBox3.Text)

            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("transactionSet/trans/trLines/trLine")
            Dim No As Integer = 0

            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el atributo del codigo
                'Dim mCodigo = m_node.Attributes.GetNamedItem("date").Value

                If m_node.ChildNodes.Item(7).Name = "trlLineTot" Then
                    If CDec(m_node.ChildNodes.Item(7).InnerText) < 0 Then
                        RichTextBox1.Text = RichTextBox1.Text + m_node.ChildNodes.Item(10).InnerText + vbNewLine
                    End If
                ElseIf m_node.ChildNodes.Item(8).Name = "trlLineTot" Then
                    If CDec(m_node.ChildNodes.Item(8).InnerText) < 0 Then
                        RichTextBox1.Text = RichTextBox1.Text + m_node.ChildNodes.Item(10).InnerText + vbNewLine
                    End If
                Else
                    RichTextBox1.Text = RichTextBox1.Text + "No se encontro"
                End If

                'No = No + 1

                'If CDec(m_node.ChildNodes.Item(7).InnerText) < 0 Then
                '    RichTextBox1.Text = RichTextBox1.Text +
                '                       No.ToString + " - " + m_node.ChildNodes.Item(0).InnerText + ", " + _
                '                                         m_node.ChildNodes.Item(1).InnerText + ", " + _
                '                                         m_node.ChildNodes.Item(2).InnerText + ", " + _
                '                                         m_node.ChildNodes.Item(3).InnerText + ", " + _
                '                                         m_node.ChildNodes.Item(4).InnerText + ", " + _
                '                                         m_node.ChildNodes.Item(5).InnerText + ", " + _
                '                                         m_node.ChildNodes.Item(6).InnerText + ", " + _
                '                                         m_node.ChildNodes.Item(7).InnerText + ", " + _
                '                                         m_node.ChildNodes.Item(8).InnerText + ", " + vbNewLine
                'End If

                ''Obtenemos el Elemento nombre
                'Dim mNombre = m_node.ChildNodes.Item(4).InnerText

                ''Obtenemos el Elemento apellido
                'Dim mApellido = m_node.ChildNodes.Item(5).InnerText

                ''Escribimos el resultado en la consola, 
                ''pero tambien podriamos utilizarlos en
                ''donde deseemos
                'MessageBox.Show("Codigo usuario: " & "" _
                '  & " Nombre: " & mNombre _
                '  & " Apellido: " & mApellido)
                'Console.Write(vbCrLf)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Esto es una prueba de control de versiones.
    End Sub
End Class
