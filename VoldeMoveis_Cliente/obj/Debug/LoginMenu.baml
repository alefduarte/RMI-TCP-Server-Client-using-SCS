   M S B A M L   `   `   `  ����N  JVoldeMoveis_Cliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:VoldeMoveis_ClienteVoldeMoveis_Cliente  5   	   #    VoldeMoveis_Cliente.LoginMenu   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:VoldeMoveis_Cliente     5   	     � Title$  	LoginMenu��5   	   $	��450��6   $	��800��6(    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J   .��5	      � 
���   �.+�5
   
   �� -   5         ��Name$ 	LoginPage��5
      .+�5      �� $��Login��6    � Cursor$
 None��6$   
�������$��Segoe UI Black)�6E   $��48(�6a   $��Center=�6o   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��5q�6�    �� Left$	 318��6�   
 �� Top$ 10��6  �� 5      $	��661��6   $	 393��6(   $
 -218��6:   $��5��6L   $��Center=�6V   $��Center=�6z    J� RenderTransformOrigin$ 0.5,0.5&�6�   ���	#FF9C9C9Cz�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$	 -90Q�6*   T� 5      5      5      �� 5      $��Usuário��6   $ 67��6&   $	 138��67   
�������$��24(�6q   ��6H   Z� 6q   �� 5      -   5        	 ��Name$	 TextBox_username��5      $��24��60   $ 67��6<   
 �� TextWrapping$

 Wrap=�6M   $	 185��6a   $	��659��6r   ���	#FF7E7E7E
�������
�������$��18(�6�   �� 5      $��Senha��6   $ 67��6$   $	 228��65   
�������$��24(�6o   ��6F   Z� 6o   �� 5      -   5         ��Name$ Button_Entrar��5      $��Entrar��6,   $	 330��6=   $	 331��6O   $	��130��6`   $��45��6l   
�������
�������$��24(�6�   ��5      �� 5       �� Color$ 	#FF9B9797��6&   5      �� 5      -   5        $��CONEXAO��5      $	 717��6'   $	 388��69   $��67��6J   $��23��6U   
�������
����������	#FF8F8F8F6�   G� 5      -   5         G�Name$ PasswordBox��5      $ 67��6/   $	 275��6@   $��24��6Q   $	��659��6]   $��18(�6i   
�������
����������	#FF7E7E7E6�   5       � 5!   
   -   5         �Name$ GridConexao��5!      
���   �$��284,89,270,115q�67   $y�Hidden=�6O   .+�5"      �� $��Configurações��6   $
��Left=�6,   $��63,0,0,0q�6G   $	��Top=�6Y   $��35��6q   $	��128��6}   
�������$��18(�6�   �� 5#      $��IP do Servidor��6   $
��Left=�6-   $��	10,39,0,0q�6H   $	��Top=�6[   $	��154��6s   
�������6   �� 5$      -   5        $	 
TextBox_IP��5$      $
��Left=�6*   $��23��6E   $��	10,65,0,0q�6Q   $

 Wrap=�6d   $	��Top=�6x   $	��220��6�   ���	#FF8B8B8B
�������
�������$��16(�6�   �� 5%      $��Porta do Servidor��6   $
��Left=�60   $��
10,102,0,0q�6K   $	��Top=�6_   $	��154��6w   
�������6�   �� 5&      -   5        $	 TextBox_Port��5&      $
��Left=�6,   $��23��6G   $��
10,128,0,0q�6S   $

 Wrap=�6g   $	��Top=�6{   $	��220��6�   ���	#FF8B8B8B
�������
�������$��16(�6�   �� 5'      -	   5        $��SALVAR��5'      $
��Left=�6&   $��
80,187,0,0q�6A   $	��Top=�6U   $��74��6m   ���	#FF767676
�������
�������6�   �� 5(      -
   5        $��X��5(      $
��Left=�6!   $��
213,10,0,0q�6<   $	��Top=�6P   $��17��6h   $��19��6s   $ 
0.52,0.535&�6�   5)      5*      5+      