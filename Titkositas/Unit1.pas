unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, ExtDlgs;

const
  Tomb_mono2:array[1..9] of String[2]=('AA','AB','AC','BA','BB','BC','CA','CB','CC');
type
  TUrlap = class(TForm)
    CsoportBox1: TGroupBox;
    Valasztobox: TComboBox;
    Nyiltszoveg: TEdit;
    Kodoltszoveg: TEdit;
    Cimke1: TLabel;
    Cimke2: TLabel;
    Gomb_titkosit: TBitBtn;
    Gomb_vissza: TBitBtn;
    Kilepes: TBitBtn;
    Info1: TLabel;
    Gomb_mezotorol: TBitBtn;
    Cimke3: TLabel;
    Kulcs: TEdit;
    Label2: TLabel;
    Info2: TLabel;
    Cimke4: TLabel;
    Kodabcszam: TComboBox;
    Gomb_general: TBitBtn;
    Gomb_kodnyit: TBitBtn;
    OpenTextFileDialog1: TOpenTextFileDialog;
    SaveTextFileDialog1: TSaveTextFileDialog;
    Gomb_kodment: TBitBtn;
    procedure SaveTextFileDialog1CanClose(Sender: TObject;
      var CanClose: Boolean);
    procedure OpenTextFileDialog1CanClose(Sender: TObject;
      var CanClose: Boolean);
    procedure Gomb_kodmentClick(Sender: TObject);
    procedure Gomb_kodnyitClick(Sender: TObject);
    procedure Gomb_generalClick(Sender: TObject);
    procedure KodabcszamChange(Sender: TObject);
    procedure ValasztoboxChange(Sender: TObject);
    procedure Gomb_mezotorolClick(Sender: TObject);
    procedure Gomb_visszaClick(Sender: TObject);
    procedure Gomb_titkositClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure KilepesClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Urlap: TUrlap;
  Tomb_mono1:array[1..3] of String[9];
  Tomb_poli1:array[1..9] of String[26];
  Tomb_Vigenere:array[1..26,1..26] of char;

implementation

{$R *.dfm}

procedure TUrlap.Gomb_generalClick(Sender: TObject);
var
  G: TextFile;
  Tomb_tolt:array[1..26] of Boolean;
  I,J,K: Integer;
  Ge: Byte;
  Ujra: Boolean;
  Msor2: String[26];
begin
  AssignFile(G,'adatokp.dat');   {polialfabetikus k�dokat tartalmaz� f�jl}
  {$I-}
  Rewrite(G);
  {$I+}
  if IOResult()=0 then
  begin
    Randomize;
    Rewrite(G);
    for I := 1 to StrToInt(Kodabcszam.Text) do
    begin
      Msor2:='';
      for K := 1 to 26 do Tomb_tolt[K]:=False;    {T�mb elemeinek False felt�lt�se}
      for J := 1 to 26 do
      begin
        Ujra:=True;
        repeat         {ciklus am�g minden bet�t el nem helyez�nk}
          Ge:=Random(26)+1+64;
          if Tomb_tolt[Ge-64]=False then
          begin
            Tomb_tolt[Ge-64]:=True;
            Msor2:=Msor2+Char(Ge);
            Ujra:=False;  {ciklusb�l ki}
          end;
        until (Ujra=False);
      end;
      Writeln(G,Msor2);    {Ki�r�s sz�veges f�jlba}
      Tomb_poli1[I]:=Msor2;  {�rt�kad�s a munkat�mbnek}
    end;
    CloseFile(G);   {F�jl z�r�sa}
  end;
end;

procedure TUrlap.Gomb_kodmentClick(Sender: TObject);
begin
  if Valasztobox.ItemIndex=0 then
  begin
    SaveTextFileDialog1.FileName:='adatokm.dat';
    SaveTextFileDialog1.Filter:='*.dat|adatokm.dat';
  end
  else
  begin
    SaveTextFileDialog1.FileName:='adatokp.dat';
    SaveTextFileDialog1.Filter:='*.dat|adatokp.dat';
  end;
  SaveTextFileDialog1.Execute;
end;

procedure TUrlap.Gomb_kodnyitClick(Sender: TObject);
begin
  if Valasztobox.ItemIndex=0 then
  begin
    OpenTextFileDialog1.FileName:='adatokm.dat';
    OpenTextFileDialog1.Filter:='*.dat|adatokm.dat';
  end
  else
  begin
    OpenTextFileDialog1.FileName:='adatokp.dat';
    OpenTextFileDialog1.Filter:='*.dat|adatokp.dat';
  end;
  OpenTextFileDialog1.Execute;
end;

procedure TUrlap.Gomb_mezotorolClick(Sender: TObject);
begin
  Nyiltszoveg.Text:='';
  Kodoltszoveg.Text:='';
  {Kulcs.Text:='';}
  Nyiltszoveg.SetFocus;
end;

procedure TUrlap.FormCreate(Sender: TObject);
var
  SI,OI,Kod: Integer;
  F,G: TextFile;
  Tomb_tolt:array[1..26] of Boolean;
  I,J,K: Integer;
  Ge,Xps,Xpo: Byte;
  Ujra: Boolean;
  Msor: String[9];
  Msor2: String[26];
begin
  AssignFile(F,'adatokm.dat');   {monoalfabetikus k�dokat tartalmaz� f�jl}
  {$I-}
  Reset(F);   {nyit�si k�s�rlet}
  {$I+}
  if IOResult()<>0 then   {Ha nincs adatf�jl -> l�trehozzuk}
  begin
    Randomize;
    Xps:=Random(3)+1;   {X poz�ci�ja v�letlenszer�en}
    Xpo:=Random(9)+1;
    Rewrite(F);
    for I := 1 to 26 do Tomb_tolt[I]:=False;    {T�mb elemeinek False felt�lt�se}
    for I := 1 to 3 do    {3 soros a m�trix}
      begin
        Msor:='';
        for J := 1 to 9 do
        begin
          if (I=Xps) and (J=Xpo) then
            Msor:=Msor+'X'
          else
          begin
            Ujra:=True;
            repeat         {ciklus am�g minden bet�t el nem helyez�nk}
              Ge:=Random(26)+1+96;
              if Tomb_tolt[Ge-96]=False then
              begin
                Tomb_tolt[Ge-96]:=True;
                Msor:=Msor+Char(Ge);
                Ujra:=False;  {ciklusb�l ki}
              end;
            until (Ujra=False);
          end;
        end;
        Writeln(F,Msor);    {Ki�r�s sz�veges f�jlba}
        Tomb_mono1[I]:=Msor;  {�rt�kad�s a munkat�mbnek}
      end;
    CloseFile(F);   {F�jl z�r�sa}
  end
  else
  begin
    I:=1;
    while not eof(F) do   {soronk�nt kiolvassuk a f�jlb�l}
    begin
      Readln(F,Msor);
      Tomb_mono1[I]:=Msor;  {�rt�kad�s a munkat�mbnek}
      Inc(I);
    end;
    CloseFile(F);   {F�jl z�r�sa}
  end;
  AssignFile(G,'adatokp.dat');   {polialfabetikus k�dokat tartalmaz� f�jl}
  {$I-}
  Reset(G);   {nyit�si k�s�rlet}
  {$I+}
  if IOResult()<>0 then   {Ha nincs adatf�jl -> l�trehozzuk}
  begin
    Randomize;
    Rewrite(G);
    for I := 1 to 2 do
    begin
      Msor2:='';
      for K := 1 to 26 do Tomb_tolt[K]:=False;    {T�mb elemeinek False felt�lt�se}
      for J := 1 to 26 do
      begin
        Ujra:=True;
        repeat         {ciklus am�g minden bet�t el nem helyez�nk}
          Ge:=Random(26)+1+64;
          if Tomb_tolt[Ge-64]=False then
          begin
            Tomb_tolt[Ge-64]:=True;
            Msor2:=Msor2+Char(Ge);
            Ujra:=False;  {ciklusb�l ki}
          end;
        until (Ujra=False);
      end;
      Writeln(G,Msor2);    {Ki�r�s sz�veges f�jlba}
      Tomb_poli1[I]:=Msor2;  {�rt�kad�s a munkat�mbnek}
    end;
    CloseFile(G);   {F�jl z�r�sa}
  end
  else
  begin
    I:=1;
    while not eof(G) do   {soronk�nt kiolvassuk a f�jlb�l}
    begin
      Readln(G,Msor2);
      Tomb_poli1[I]:=Msor2;  {�rt�kad�s a munkat�mbnek}
      Inc(I);
    end;
    CloseFile(G);   {F�jl z�r�sa}
  end;
  Kodabcszam.Itemindex:=I-1;    {a beolvasott sorok sz�m�nak figyelembe v�tele}
  Kodabcszam.Text:=inttostr(I-1);
  for SI := 1 to 26 do    {Vigenere-t�bla m�trixanak felt�lt�se}
    for OI := 1 to 26 do
    begin
      Kod:=64+SI+OI-1;
      if Kod>90 then
        Kod:=Kod-26;
      Tomb_Vigenere[SI,OI]:=Char(Kod);
    end;
  Valasztobox.ItemIndex:=0;
  Nyiltszoveg.Text:='';
  Kodoltszoveg.Text:='';
  Kulcs.Text:='';
  Cimke3.Visible:=False;
  Cimke4.Visible:=False;
  Kulcs.Visible:=False;
  Kodabcszam.Visible:=False;
  Gomb_general.Visible:=False;
  Gomb_kodnyit.Visible:=True;
  Gomb_kodment.Visible:=True;
end;

procedure TUrlap.Gomb_titkositClick(Sender: TObject);
var
  I,S,O: Integer;
  Kodhossz,Kodsor,Kodoszlop,Poz,Hiba: Integer;
  Tomb_Kulcs: array[1..26] of Byte; {A kulcs ABC-nek t�mb}
begin
  if Nyiltszoveg.Text<>'' then
  begin
    Nyiltszoveg.Text:=Trim(Nyiltszoveg.Text); {bevezet� �s lez�r� sz�k�z�k elt�vol�t�sa}
    Nyiltszoveg.Text:=StringReplace(Nyiltszoveg.Text,' ','',[rfReplaceAll]);  {sz�k�z�k elt�vol�t�sa}
    Kodoltszoveg.Text:='';
    case Valasztobox.ItemIndex of
      0:begin   {Monoalfabetikus k�dok}
          for I := 1 to Length(Nyiltszoveg.Text) do
            for S := 1 to 3 do    {Keres�s a t�mbben}
              for O := 1 to 9 do
              begin
                if Nyiltszoveg.Text[I]=Tomb_mono1[S,O] then {Megvan a karakter!}
                   Kodoltszoveg.Text:=Kodoltszoveg.Text+ Char(64+S)+ Tomb_mono2[O];
              end;
        end;
      1:begin   {Polialfabetikus k�dok}
          if Kulcs.Text<>'' then  {csak ha nem �res a kulcs mez�!}
            begin
              Kodhossz:=Length(Kulcs.Text);
              for I := 1 to Length(Nyiltszoveg.Text) do
              begin
                Poz:=(I mod Kodhossz);  {marad�kk�pz�s, hanyadik k�dsort alkalmazzuk}
                if Poz=0 then Val( Copy(Kulcs.Text,Length(Kulcs.Text),1),Kodsor,Hiba) {0 marad�k -> utols� k�dsor}
                         else Val( Copy(Kulcs.Text,Poz,1),Kodsor,Hiba);
                Kodoszlop:=Ord( Nyiltszoveg.Text[I]); { Karakterk�d meghat�roz�sa }
                Kodoszlop:=Kodoszlop-96;  {ASCII-k�db�l -96}
                Kodoltszoveg.Text:=Kodoltszoveg.Text+Copy(Tomb_poli1[Kodsor],Kodoszlop,1);
              end;
            end
            else ShowMessage(' A k�d mez� �res! ');
        end;
      2:begin   {Vigenere-t�bla}
          if Kulcs.Text<>'' then  {csak ha nem �res a kulcs!}
          begin
            Kodhossz:=Length(Kulcs.Text);
            for I := 1 to Kodhossz do
              Tomb_Kulcs[I]:=Ord(Kulcs.Text[I])-64; {T�mbbe tessz�k az oszlopok sorsz�m�t}
            for I := 1 to Length(Nyiltszoveg.Text) do
            begin
              Kodoszlop:=(I mod Kodhossz);  {marad�kk�pz�s, hanyadik k�doszlopot alkalmazzuk}
              if Kodoszlop=0 then
                Kodoszlop:=Kodhossz;
              Kodoltszoveg.Text:=Kodoltszoveg.Text+Tomb_Vigenere[ Ord(Nyiltszoveg.Text[I])-96, Tomb_Kulcs[Kodoszlop]];  {K�dkiv�tel a m�trixb�l}
            end;
          end;
        end;
    end;
  end
    else ShowMessage(' �res a k�doland� sz�veg mez�! ');
end;

procedure TUrlap.Gomb_visszaClick(Sender: TObject);
var
  I,J: Integer;
  UjKar: Char;
  Kodhossz,Kodsor,Poz,Hiba: Integer;
  Tomb_Kulcs: array[1..26] of Byte; {A kulcs ABC-nek t�mb}
begin
  if Kodoltszoveg.Text<>'' then
  begin
    Kodoltszoveg.Text:=Trim(Kodoltszoveg.Text); {bevezet� �s lez�r� sz�k�z�k elt�vol�t�sa}
    Kodoltszoveg.Text:=StringReplace(Kodoltszoveg.Text,' ','',[rfReplaceAll]);
    Nyiltszoveg.Text:='';
    case Valasztobox.ItemIndex of
      0:begin   {Monoalfabetikus k�dok}
          i:=1;
          while I <= Length(Kodoltszoveg.Text) do {ciklus a string karakterein}
          begin
            j:=1;
            while J<=9 do
            begin
              if Tomb_mono2[J]=Kodoltszoveg.Text[I+1]+Kodoltszoveg.Text[I+2] then break;
              Inc(J);
            end;
            UjKar:=Tomb_mono1[ Ord(Kodoltszoveg.Text[I])-64, J];
            if UjKar in ['a'..'z'] then {Ha az �j karakter kisbet�}
              Nyiltszoveg.Text:=Nyiltszoveg.Text+ UjKar;
            I:=I+3; {3-as blokkokat dolgozunk fel}
          end;
        end;
      1:begin   {Polialfabetikus k�dok}
          if Kulcs.Text<>'' then  {csak ha nem �res a kulcs!}
          begin
            Kodhossz:=Length(Kulcs.Text);
            for I := 1 to Length(Kodoltszoveg.Text) do
            begin
              Poz:=(I mod Kodhossz);
              if Poz=0 then Val( Copy(Kulcs.Text,Length(Kulcs.Text),1),Kodsor,Hiba)
                       else Val( Copy(Kulcs.Text,Poz,1),Kodsor,Hiba);
              j:=1;
              while J<=26 do
              begin
                if Copy (Tomb_poli1[Kodsor],J,1)=Kodoltszoveg.Text[I] then break;
                Inc(J);
              end;
              UjKar:=Char(96+J);
              if UjKar in ['a'..'z'] then {Ha az �j karakter kisbet�}
                Nyiltszoveg.Text:=Nyiltszoveg.Text+ UjKar;
            end;
          end
            else ShowMessage(' A k�d mez� �res! ');
        end;
      2:begin   {Vigenere-t�bla}
          if Kulcs.Text<>'' then  {csak ha nem �res a kulcs!}
          begin
            Kodhossz:=Length(Kulcs.Text);
            for I := 1 to Kodhossz do
                Tomb_Kulcs[I]:=Ord(Kulcs.Text[I])-64; {T�mbbe tessz�k az oszlopok sorsz�m�t}
            for i := 1 to Length(Kodoltszoveg.Text) do
            begin
              Poz:=(I mod Kodhossz);    {kulcspoz�ci� meghat�roz�sa}
              if Poz=0 then
                Poz:=Kodhossz;
              j:=1;
              while J<=26 do
              begin
                if Kodoltszoveg.Text[I]=Tomb_Vigenere[J, Tomb_kulcs[Poz]] then break; {Megvan a karakter!}
                Inc(J);
              end;
              UjKar:=Char(96+J);
              if UjKar in ['a'..'z'] then {Ha az �j karakter kisbet�}
                Nyiltszoveg.Text:=Nyiltszoveg.Text+ UjKar;
            end;
          end
            else ShowMessage(' A k�d mez� �res! ');
        end;
    end;
  end
    else ShowMessage(' �res a titkos�tott sz�veg mez�! ');
end;

procedure TUrlap.KilepesClick(Sender: TObject);
begin
  Close;
end;

procedure TUrlap.KodabcszamChange(Sender: TObject);
begin
  Info2.Caption:='<-- "1"-"'+IntToStr(Kodabcszam.ItemIndex+2)+'"-es sz�mjegyek';
end;

procedure TUrlap.OpenTextFileDialog1CanClose(Sender: TObject;
  var CanClose: Boolean);
var
  F: TextFile;
  I: Integer;
  Msor: String[9];
  Msor2: String[26];
  Fajl: String;
begin
  Fajl:=OpenTextFileDialog1.Filename;
  AssignFile(F,Fajl);   {monoalfabetikus k�dokat tartalmaz� f�jl}
  Reset(F);   {nyit�si k�s�rlet}
  if Fajl='adatokm.dat' then
    begin
      I:=1;
      while not eof(F) do   {soronk�nt kiolvassuk a f�jlb�l}
      begin
        Readln(F,Msor);
        Tomb_mono1[I]:=Msor;  {�rt�kad�s a munkat�mbnek}
        Inc(I);
      end;
    end
  else
    begin
      I:=1;
      while not eof(F) do   {soronk�nt kiolvassuk a f�jlb�l}
      begin
        Readln(F,Msor2);
        Tomb_poli1[I]:=Msor2;  {�rt�kad�s a munkat�mbnek}
        Inc(I);
      end;
      Kodabcszam.Itemindex:=I-1;    {a beolvasott sorok sz�m�nak figyelembe v�tele}
      Kodabcszam.Text:=inttostr(I-1);
    end;
  CloseFile(F);   {F�jl z�r�sa}
end;

procedure TUrlap.SaveTextFileDialog1CanClose(Sender: TObject;
  var CanClose: Boolean);
var
  I: Integer;
  F: TextFile;
  Fajl: String;
begin
  Fajl:=SaveTextFileDialog1.FileName;
  AssignFile(F,Fajl);
  Rewrite(F);
  if Fajl='adatokm.dat' then        {Ki�r�s f�jlba}
    begin
      for I := 1 to 3 do    {3 soros a m�trix}
        Writeln(F,Tomb_mono1[I]);  {�rt�kad�s a munkat�mbnek}
    end
  else
    begin
      for I := 1 to StrToInt(Kodabcszam.Text) do
        Writeln(F,Tomb_poli1[I]);
    end;
  CloseFile(F);   {F�jl z�r�sa}
end;

procedure TUrlap.ValasztoboxChange(Sender: TObject);
begin
  Cimke3.Visible:=True;
  Cimke4.Visible:=True;
  Kulcs.Visible:=True;
  Kodabcszam.Visible:=True;
  Gomb_general.Visible:=False;
  Gomb_kodnyit.Visible:=True;
  Gomb_kodment.Visible:=True;
  case Valasztobox.ItemIndex of   {Kulcs mez� megjelen�t�se/rejt�se}
    0:begin
        Cimke3.Visible:=False;
        Cimke4.Visible:=False;
        Kulcs.Visible:=False;
        Info2.Caption:='';
        Kodabcszam.Visible:=False;
      end;
    1:begin
        Kulcs.Text:='212';
        Info2.Caption:='<-- "1"-"2"-es sz�mjegyek';
        Gomb_general.Visible:=True;
      end;
    2:begin
        Kulcs.Text:='KULCS';
        Info2.Caption:='<-- "A" - "Z" karakterek';
        Cimke4.Visible:=False;
        Kodabcszam.Visible:=False;
        Gomb_kodnyit.Visible:=False;
        Gomb_kodment.Visible:=False;
      end;
  end;
end;

end.
