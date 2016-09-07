program titok1;

uses
  Forms,
  Unit1 in 'Unit1.pas' {Urlap};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TUrlap, Urlap);
  Application.Run;
end.
