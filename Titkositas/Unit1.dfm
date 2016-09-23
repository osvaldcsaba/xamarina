object Urlap: TUrlap
  Left = 213
  Top = 206
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 'TITOK v1.4 - (c) K'#233'sz'#237'tette: Osvald Csaba - OSCOAAT.PTE'
  ClientHeight = 378
  ClientWidth = 619
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -16
  Font.Name = 'Tahoma'
  Font.Style = [fsBold]
  OldCreateOrder = False
  Position = poDesigned
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 19
  object Label2: TLabel
    Left = 72
    Top = 280
    Width = 5
    Height = 19
  end
  object CsoportBox1: TGroupBox
    Left = 0
    Top = 0
    Width = 619
    Height = 313
    Align = alTop
    Caption = 'Titkos'#237't'#225'si elj'#225'r'#225's v'#225'laszt'#225'sa'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    object Cimke1: TLabel
      Left = 16
      Top = 64
      Width = 134
      Height = 19
      Caption = 'K'#243'doland'#243' sz'#246'veg:'
    end
    object Cimke2: TLabel
      Left = 16
      Top = 104
      Width = 130
      Height = 19
      Caption = 'Titkos'#237'tott sz'#246'veg:'
    end
    object Info1: TLabel
      Left = 304
      Top = 26
      Width = 267
      Height = 19
      Caption = 'Sz'#246'veg megad'#225'sa '#233'kezet n'#233'lk'#252'l!'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlue
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Cimke3: TLabel
      Left = 16
      Top = 146
      Width = 118
      Height = 19
      Caption = 'Kulcs megad'#225'sa:'
    end
    object Info2: TLabel
      Left = 287
      Top = 146
      Width = 5
      Height = 19
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clBlue
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object Cimke4: TLabel
      Left = 16
      Top = 192
      Width = 131
      Height = 19
      Caption = 'K'#243'd ABC-k sz'#225'ma:'
    end
    object Valasztobox: TComboBox
      Left = 16
      Top = 23
      Width = 249
      Height = 27
      Hint = 'Titkos'#237't'#225'si elj'#225'r'#225's v'#225'laszt'#225'sa'
      Style = csDropDownList
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ItemHeight = 19
      ItemIndex = 0
      ParentFont = False
      ParentShowHint = False
      ShowHint = True
      TabOrder = 0
      Text = 'Monoalfabetikus k'#243'dok'
      OnChange = ValasztoboxChange
      Items.Strings = (
        'Monoalfabetikus k'#243'dok'
        'Polialfabetikus k'#243'dok'
        'Vigenere-t'#225'bla')
    end
    object Nyiltszoveg: TEdit
      Left = 160
      Top = 61
      Width = 441
      Height = 27
      Hint = 'Itt adja meg '#233'kezetek n'#233'lk'#252'l a k'#243'doland'#243' sz'#246'veget!'
      CharCase = ecLowerCase
      ParentShowHint = False
      ShowHint = True
      TabOrder = 1
    end
    object Kodoltszoveg: TEdit
      Left = 160
      Top = 101
      Width = 441
      Height = 27
      Hint = 'A titkos'#237'tott sz'#246'veg itt olvashat'#243
      CharCase = ecUpperCase
      ParentShowHint = False
      ShowHint = True
      TabOrder = 2
    end
    object Gomb_titkosit: TBitBtn
      Left = 16
      Top = 274
      Width = 153
      Height = 33
      Caption = '&Titkos'#237't'#225's!'
      Default = True
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ModalResult = 1
      ParentFont = False
      TabOrder = 3
      OnClick = Gomb_titkositClick
      Glyph.Data = {
        DE010000424DDE01000000000000760000002800000024000000120000000100
        0400000000006801000000000000000000001000000000000000000000000000
        80000080000000808000800000008000800080800000C0C0C000808080000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333333
        3333333333333333333333330000333333333333333333333333F33333333333
        00003333344333333333333333388F3333333333000033334224333333333333
        338338F3333333330000333422224333333333333833338F3333333300003342
        222224333333333383333338F3333333000034222A22224333333338F338F333
        8F33333300003222A3A2224333333338F3838F338F33333300003A2A333A2224
        33333338F83338F338F33333000033A33333A222433333338333338F338F3333
        0000333333333A222433333333333338F338F33300003333333333A222433333
        333333338F338F33000033333333333A222433333333333338F338F300003333
        33333333A222433333333333338F338F00003333333333333A22433333333333
        3338F38F000033333333333333A223333333333333338F830000333333333333
        333A333333333333333338330000333333333333333333333333333333333333
        0000}
      NumGlyphs = 2
    end
    object Gomb_vissza: TBitBtn
      Left = 185
      Top = 274
      Width = 153
      Height = 33
      Caption = '&Visszafejt'#233's'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ModalResult = 4
      ParentFont = False
      TabOrder = 4
      OnClick = Gomb_visszaClick
      Glyph.Data = {
        DE010000424DDE01000000000000760000002800000024000000120000000100
        0400000000006801000000000000000000001000000000000000000000000000
        80000080000000808000800000008000800080800000C0C0C000808080000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333444444
        33333333333F8888883F33330000324334222222443333388F3833333388F333
        000032244222222222433338F8833FFFFF338F3300003222222AAAAA22243338
        F333F88888F338F30000322222A33333A2224338F33F8333338F338F00003222
        223333333A224338F33833333338F38F00003222222333333A444338FFFF8F33
        3338888300003AAAAAAA33333333333888888833333333330000333333333333
        333333333333333333FFFFFF000033333333333344444433FFFF333333888888
        00003A444333333A22222438888F333338F3333800003A2243333333A2222438
        F38F333333833338000033A224333334422224338338FFFFF8833338000033A2
        22444442222224338F3388888333FF380000333A2222222222AA243338FF3333
        33FF88F800003333AA222222AA33A3333388FFFFFF8833830000333333AAAAAA
        3333333333338888883333330000333333333333333333333333333333333333
        0000}
      NumGlyphs = 2
    end
    object Gomb_mezotorol: TBitBtn
      Left = 352
      Top = 274
      Width = 153
      Height = 33
      Caption = '&Mez'#337'k t'#246'rl'#233'se'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = [fsBold]
      ParentFont = False
      TabOrder = 5
      OnClick = Gomb_mezotorolClick
      Kind = bkCancel
    end
    object Kulcs: TEdit
      Left = 160
      Top = 143
      Width = 121
      Height = 27
      Hint = 'Titkos'#237't'#225'si kulcs megad'#225'sa'
      CharCase = ecUpperCase
      ParentShowHint = False
      ShowHint = True
      TabOrder = 6
    end
    object Kodabcszam: TComboBox
      Left = 160
      Top = 189
      Width = 121
      Height = 27
      Hint = 'K'#243'd ABC-k sz'#225'm'#225'nak megad'#225'sa'
      ItemHeight = 19
      ParentShowHint = False
      ShowHint = True
      TabOrder = 7
      OnChange = KodabcszamChange
      Items.Strings = (
        '2'
        '3'
        '4'
        '5'
        '6'
        '7'
        '8'
        '9')
    end
    object Gomb_general: TBitBtn
      Left = 352
      Top = 235
      Width = 153
      Height = 33
      Hint = 'K'#243'd gener'#225'l'#225'sa, f'#225'jlba '#237'r'#225'sa'
      Caption = 'K'#243'd &gener'#225'l'#225'sa'
      ParentShowHint = False
      ShowHint = True
      TabOrder = 8
      OnClick = Gomb_generalClick
      Kind = bkIgnore
    end
    object Gomb_kodnyit: TBitBtn
      Left = 16
      Top = 235
      Width = 153
      Height = 33
      Hint = 'K'#243'd'#225'llom'#225'ny nyit'#225'sa'
      Caption = 'K'#243'&df'#225'jl nyit'#225'sa'
      ParentShowHint = False
      ShowHint = True
      TabOrder = 9
      OnClick = Gomb_kodnyitClick
      NumGlyphs = 2
    end
    object Gomb_kodment: TBitBtn
      Left = 185
      Top = 235
      Width = 153
      Height = 33
      Hint = 'K'#243'd'#225'llom'#225'ny ment'#233'se'
      Caption = 'K'#243'df'#225'jl ment'#233'&se'
      ParentShowHint = False
      ShowHint = True
      TabOrder = 10
      OnClick = Gomb_kodmentClick
    end
  end
  object Kilepes: TBitBtn
    Left = 472
    Top = 328
    Width = 129
    Height = 33
    Caption = '&Kil'#233'p'#233's'
    TabOrder = 1
    OnClick = KilepesClick
    Glyph.Data = {
      DE010000424DDE01000000000000760000002800000024000000120000000100
      0400000000006801000000000000000000001000000000000000000000000000
      80000080000000808000800000008000800080800000C0C0C000808080000000
      FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00388888888877
      F7F787F8888888888333333F00004444400888FFF444448888888888F333FF8F
      000033334D5007FFF4333388888888883338888F0000333345D50FFFF4333333
      338F888F3338F33F000033334D5D0FFFF43333333388788F3338F33F00003333
      45D50FEFE4333333338F878F3338F33F000033334D5D0FFFF43333333388788F
      3338F33F0000333345D50FEFE4333333338F878F3338F33F000033334D5D0FFF
      F43333333388788F3338F33F0000333345D50FEFE4333333338F878F3338F33F
      000033334D5D0EFEF43333333388788F3338F33F0000333345D50FEFE4333333
      338F878F3338F33F000033334D5D0EFEF43333333388788F3338F33F00003333
      4444444444333333338F8F8FFFF8F33F00003333333333333333333333888888
      8888333F00003333330000003333333333333FFFFFF3333F00003333330AAAA0
      333333333333888888F3333F00003333330000003333333333338FFFF8F3333F
      0000}
    NumGlyphs = 2
  end
  object OpenTextFileDialog1: TOpenTextFileDialog
    DefaultExt = '*.dat'
    Filter = 
      'Monoalfabetikus k'#243'df'#225'jl|adatokm.dat|Polialfabetikus k'#243'df'#225'jl|adat' +
      'okp.dat'
    OnCanClose = OpenTextFileDialog1CanClose
    Left = 512
    Top = 232
  end
  object SaveTextFileDialog1: TSaveTextFileDialog
    DefaultExt = '*.dat'
    Filter = 
      'Monoalfabetikus k'#243'df'#225'jl|adatokm.dat|Polialfabetikus k'#243'df'#225'jl|adat' +
      'okp.dat'
    OnCanClose = SaveTextFileDialog1CanClose
    Left = 544
    Top = 232
  end
end
