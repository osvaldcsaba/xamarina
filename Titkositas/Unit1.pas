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
  AssignFile(G,'adatokp.dat');   {polialfabetikus kódokat tartalmazó fájl}
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
      for K := 1 to 26 do Tomb_tolt[K]:=False;    {Tömb elemeinek False feltöltése}
      for J := 1 to 26 do
      begin
        Ujra:=True;
        repeat         {ciklus amíg minden betût el nem helyezünk}
          Ge:=Random(26)+1+64;
          if Tomb_tolt[Ge-64]=False then
          begin
            Tomb_tolt[Ge-64]:=True;
            Msor2:=Msor2+Char(Ge);
            Ujra:=False;  {ciklusból ki}
          end;
        until (Ujra=False);
      end;
      Writeln(G,Msor2);    {Kiírás szöveges fájlba}
      Tomb_poli1[I]:=Msor2;  {Értékadás a munkatömbnek}
    end;
    CloseFile(G);   {Fájl zárása}
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
  AssignFile(F,'adatokm.dat');   {monoalfabetikus kódokat tartalmazó fájl}
  {$I-}
  Reset(F);   {nyitási kísérlet}
  {$I+}
  if IOResult()<>0 then   {Ha nincs adatfájl -> létrehozzuk}
  begin
    Randomize;
    Xps:=Random(3)+1;   {X pozíciója véletlenszerûen}
    Xpo:=Random(9)+1;
    Rewrite(F);
    for I := 1 to 26 do Tomb_tolt[I]:=False;    {Tömb elemeinek False feltöltése}
    for I := 1 to 3 do    {3 soros a mátrix}
      begin
        Msor:='';
        for J := 1 to 9 do
        begin
          if (I=Xps) and (J=Xpo) then
            Msor:=Msor+'X'
          else
          begin
            Ujra:=True;
            repeat         {ciklus amíg minden betût el nem helyezünk}
              Ge:=Random(26)+1+96;
              if Tomb_tolt[Ge-96]=False then
              begin
                Tomb_tolt[Ge-96]:=True;
                Msor:=Msor+Char(Ge);
                Ujra:=False;  {ciklusból ki}
              end;
            until (Ujra=False);
          end;
        end;
        Writeln(F,Msor);    {Kiírás szöveges fájlba}
        Tomb_mono1[I]:=Msor;  {Értékadás a munkatömbnek}
      end;
    CloseFile(F);   {Fájl zárása}
  end
  else
  begin
    I:=1;
    while not eof(F) do   {soronként kiolvassuk a fájlból}
    begin
      Readln(F,Msor);
      Tomb_mono1[I]:=Msor;  {Értékadás a munkatömbnek}
      Inc(I);
    end;
    CloseFile(F);   {Fájl zárása}
  end;
  AssignFile(G,'adatokp.dat');   {polialfabetikus kódokat tartalmazó fájl}
  {$I-}
  Reset(G);   {nyitási kísérlet}
  {$I+}
  if IOResult()<>0 then   {Ha nincs adatfájl -> létrehozzuk}
  begin
    Randomize;
    Rewrite(G);
    for I := 1 to 2 do
    begin
      Msor2:='';
      for K := 1 to 26 do Tomb_tolt[K]:=False;    {Tömb elemeinek False feltöltése}
      for J := 1 to 26 do
      begin
        Ujra:=True;
        repeat         {ciklus amíg minden betût el nem helyezünk}
          Ge:=Random(26)+1+64;
          if Tomb_tolt[Ge-64]=False then
          begin
            Tomb_tolt[Ge-64]:=True;
            Msor2:=Msor2+Char(Ge);
            Ujra:=False;  {ciklusból ki}
          end;
        until (Ujra=False);
      end;
      Writeln(G,Msor2);    {Kiírás szöveges fájlba}
      Tomb_poli1[I]:=Msor2;  {Értékadás a munkatömbnek}
    end;
    CloseFile(G);   {Fájl zárása}
  end
  else
  begin
    I:=1;
    while not eof(G) do   {soronként kiolvassuk a fájlból}
    begin
      Readln(G,Msor2);
      Tomb_poli1[I]:=Msor2;  {Értékadás a munkatömbnek}
      Inc(I);
    end;
    CloseFile(G);   {Fájl zárása}
  end;
  Kodabcszam.Itemindex:=I-1;    {a beolvasott sorok számának figyelembe vétele}
  Kodabcszam.Text:=inttostr(I-1);
  for SI := 1 to 26 do    {Vigenere-tábla mátrixanak feltöltése}
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
  Tomb_Kulcs: array[1..26] of Byte; {A kulcs ABC-nek tömb}
begin
  if Nyiltszoveg.Text<>'' then
  begin
    Nyiltszoveg.Text:=Trim(Nyiltszoveg.Text); {bevezetõ és lezáró szóközök eltávolítása}
    Nyiltszoveg.Text:=StringReplace(Nyiltszoveg.Text,' ','',[rfReplaceAll]);  {szóközök eltávolítása}
    Kodoltszoveg.Text:='';
    case Valasztobox.ItemIndex of
      0:begin   {Monoalfabetikus kódok}
          for I := 1 to Length(Nyiltszoveg.Text) do
            for S := 1 to 3 do    {Keresés a tömbben}
              for O := 1 to 9 do
              begin
                if Nyiltszoveg.Text[I]=Tomb_mono1[S,O] then {Megvan a karakter!}
                   Kodoltszoveg.Text:=Kodoltszoveg.Text+ Char(64+S)+ Tomb_mono2[O];
              end;
        end;
      1:begin   {Polialfabetikus kódok}
          if Kulcs.Text<>'' then  {csak ha nem üres a kulcs mezõ!}
            begin
              Kodhossz:=Length(Kulcs.Text);
              for I := 1 to Length(Nyiltszoveg.Text) do
              begin
                Poz:=(I mod Kodhossz);  {maradékképzés, hanyadik kódsort alkalmazzuk}
                if Poz=0 then Val( Copy(Kulcs.Text,Length(Kulcs.Text),1),Kodsor,Hiba) {0 maradék -> utolsó kódsor}
                         else Val( Copy(Kulcs.Text,Poz,1),Kodsor,Hiba);
                Kodoszlop:=Ord( Nyiltszoveg.Text[I]); { Karakterkód meghatározása }
                Kodoszlop:=Kodoszlop-96;  {ASCII-kódból -96}
                Kodoltszoveg.Text:=Kodoltszoveg.Text+Copy(Tomb_poli1[Kodsor],Kodoszlop,1);
              end;
            end
            else ShowMessage(' A kód mezõ üres! ');
        end;
      2:begin   {Vigenere-tábla}
          if Kulcs.Text<>'' then  {csak ha nem üres a kulcs!}
          begin
            Kodhossz:=Length(Kulcs.Text);
            for I := 1 to Kodhossz do
              Tomb_Kulcs[I]:=Ord(Kulcs.Text[I])-64; {Tömbbe tesszük az oszlopok sorszámát}
            for I := 1 to Length(Nyiltszoveg.Text) do
            begin
              Kodoszlop:=(I mod Kodhossz);  {maradékképzés, hanyadik kódoszlopot alkalmazzuk}
              if Kodoszlop=0 then
                Kodoszlop:=Kodhossz;
              Kodoltszoveg.Text:=Kodoltszoveg.Text+Tomb_Vigenere[ Ord(Nyiltszoveg.Text[I])-96, Tomb_Kulcs[Kodoszlop]];  {Kódkivétel a mátrixból}
            end;
          end;
        end;
    end;
  end
    else ShowMessage(' Üres a kódolandó szöveg mezõ! ');
end;

procedure TUrlap.Gomb_visszaClick(Sender: TObject);
var
  I,J: Integer;
  UjKar: Char;
  Kodhossz,Kodsor,Poz,Hiba: Integer;
  Tomb_Kulcs: array[1..26] of Byte; {A kulcs ABC-nek tömb}
begin
  if Kodoltszoveg.Text<>'' then
  begin
    Kodoltszoveg.Text:=Trim(Kodoltszoveg.Text); {bevezetõ és lezáró szóközök eltávolítása}
    Kodoltszoveg.Text:=StringReplace(Kodoltszoveg.Text,' ','',[rfReplaceAll]);
    Nyiltszoveg.Text:='';
    case Valasztobox.ItemIndex of
      0:begin   {Monoalfabetikus kódok}
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
            if UjKar in ['a'..'z'] then {Ha az új karakter kisbetû}
              Nyiltszoveg.Text:=Nyiltszoveg.Text+ UjKar;
            I:=I+3; {3-as blokkokat dolgozunk fel}
          end;
        end;
      1:begin   {Polialfabetikus kódok}
          if Kulcs.Text<>'' then  {csak ha nem üres a kulcs!}
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
              if UjKar in ['a'..'z'] then {Ha az új karakter kisbetû}
                Nyiltszoveg.Text:=Nyiltszoveg.Text+ UjKar;
            end;
          end
            else ShowMessage(' A kód mezõ üres! ');
        end;
      2:begin   {Vigenere-tábla}
          if Kulcs.Text<>'' then  {csak ha nem üres a kulcs!}
          begin
            Kodhossz:=Length(Kulcs.Text);
            for I := 1 to Kodhossz do
                Tomb_Kulcs[I]:=Ord(Kulcs.Text[I])-64; {Tömbbe tesszük az oszlopok sorszámát}
            for i := 1 to Length(Kodoltszoveg.Text) do
            begin
              Poz:=(I mod Kodhossz);    {kulcspozíció meghatározása}
              if Poz=0 then
                Poz:=Kodhossz;
              j:=1;
              while J<=26 do
              begin
                if Kodoltszoveg.Text[I]=Tomb_Vigenere[J, Tomb_kulcs[Poz]] then break; {Megvan a karakter!}
                Inc(J);
              end;
              UjKar:=Char(96+J);
              if UjKar in ['a'..'z'] then {Ha az új karakter kisbetû}
                Nyiltszoveg.Text:=Nyiltszoveg.Text+ UjKar;
            end;
          end
            else ShowMessage(' A kód mezõ üres! ');
        end;
    end;
  end
    else ShowMessage(' Üres a titkosított szöveg mezõ! ');
end;

procedure TUrlap.KilepesClick(Sender: TObject);
begin
  Close;
end;

procedure TUrlap.KodabcszamChange(Sender: TObject);
begin
  Info2.Caption:='<-- "1"-"'+IntToStr(Kodabcszam.ItemIndex+2)+'"-es számjegyek';
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
  AssignFile(F,Fajl);   {monoalfabetikus kódokat tartalmazó fájl}
  Reset(F);   {nyitási kísérlet}
  if Fajl='adatokm.dat' then
    begin
      I:=1;
      while not eof(F) do   {soronként kiolvassuk a fájlból}
      begin
        Readln(F,Msor);
        Tomb_mono1[I]:=Msor;  {Értékadás a munkatömbnek}
        Inc(I);
      end;
    end
  else
    begin
      I:=1;
      while not eof(F) do   {soronként kiolvassuk a fájlból}
      begin
        Readln(F,Msor2);
        Tomb_poli1[I]:=Msor2;  {Értékadás a munkatömbnek}
        Inc(I);
      end;
      Kodabcszam.Itemindex:=I-1;    {a beolvasott sorok számának figyelembe vétele}
      Kodabcszam.Text:=inttostr(I-1);
    end;
  CloseFile(F);   {Fájl zárása}
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
  if Fajl='adatokm.dat' then        {Kiírás fájlba}
    begin
      for I := 1 to 3 do    {3 soros a mátrix}
        Writeln(F,Tomb_mono1[I]);  {Értékadás a munkatömbnek}
    end
  else
    begin
      for I := 1 to StrToInt(Kodabcszam.Text) do
        Writeln(F,Tomb_poli1[I]);
    end;
  CloseFile(F);   {Fájl zárása}
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
  case Valasztobox.ItemIndex of   {Kulcs mezõ megjelenítése/rejtése}
    0:begin
        Cimke3.Visible:=False;
        Cimke4.Visible:=False;
        Kulcs.Visible:=False;
        Info2.Caption:='';
        Kodabcszam.Visible:=False;
      end;
    1:begin
        Kulcs.Text:='212';
        Info2.Caption:='<-- "1"-"2"-es számjegyek';
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
