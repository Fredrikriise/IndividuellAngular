import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { FAQ, IFAQ } from "./KundeService";
import { InnSporsmal, IInnsporsmal } from "./KundeService";


@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent {
    visInnsporsmal: boolean;
    InnsporsmalStatus: string;
    visInnsporsmalListe: boolean;
    alleInnsporsmal: Array<InnSporsmal>;
    InnsporsmalSkjema: FormGroup;

    laster: boolean;
    visHjem: boolean;

    visFAQ: boolean;
    FAQStatus: string;
    visFAQListe: boolean;
    alleFAQ: Array<FAQ>;
    FAQSkjema: FormGroup;


    constructor(private _http: HttpClient, private fb: FormBuilder) {
        this.InnsporsmalSkjema = fb.group({
            id: [""],
            navn: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-.0-9]{2,50}")])],
            email: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$")])],
            sporsmal: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zøæåA-ZØÆÅ.0-9#&/()%?!,@+'-_:; \\-]{5,999}$")])],
        });

        this.FAQSkjema = fb.group({
            id: [""],
            kategori: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-.0-9]{2,50}")])],
            sporsmal: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zøæåA-ZØÆÅ.0-9#&/()%?!,@+'-_:; \\-]{5,9999}$")])],
            svar: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zøæåA-ZØÆÅ.0-9#&/()%?!,@+'-_:; \\-]{5,9999}$")])]
        });
    }

    ngOnInit() {
        this.laster = true;
        this.hentAlleFAQ();
        this.visFAQ = false;
        this.visFAQListe = false;
        this.visHjem = true;
        this.hentAlleInnsporsmal();
        this.visInnsporsmal = false;
        this.visInnsporsmalListe = false;
    }

    onSubmit() {
        if (this.InnsporsmalStatus == "RegistrereSporsmal") {
            this.lagreInnsporsmal();
        }
        else if (this.InnsporsmalStatus == "Endre") {
            this.endreEtInnsporsmal();
        }
        else {
            alert("Feil i applikasjonen!");
        }
/*
        if (this.FAQStatus == "Registrere") {
            this.lagreFAQ();
        }
        else if (this.FAQStatus == "Endre") {
            this.endreEnFAQ();
        }
        else {
            alert("Feil i applikasjonen!");
        } */
    }

    hentAlleInnsporsmal() {
        this._http.get<IInnsporsmal[]>("api/innsporsmal/")
            .subscribe(
                Innsporsmalene => {
                    this.alleInnsporsmal = Innsporsmalene;
                    this.laster = false;
                    console.log("Ferdig med post-api/innsporsmal");
                },
                error => alert(error),
            );
    };

    tilbakeTilInnsporsmal() {
        this.hentAlleInnsporsmal();
        this.visInnsporsmalListe = true;
        this.visInnsporsmal = false;
        this.visHjem = false;
        this.visFAQ = false;
        this.visFAQListe = false;
    }

    tilbakeTilHjem() {
        this.visInnsporsmalListe = false;
        this.visInnsporsmal = false;
        this.visHjem = true;
        this.visFAQ = false;
        this.visFAQListe = false;
    }

    lagreInnsporsmal() {
        var lagretInnsporsmal = new InnSporsmal();

        lagretInnsporsmal.navn = this.InnsporsmalSkjema.value.navn;
        lagretInnsporsmal.email = this.InnsporsmalSkjema.value.email;
        lagretInnsporsmal.sporsmal = this.InnsporsmalSkjema.value.sporsmal;


        const body: string = JSON.stringify(lagretInnsporsmal);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.post("api/innsporsmal", body, { headers: headers })
            .subscribe(
                () => {
                    this.registrerInnsporsmal();
                    //this.hentAlleInnsporsmal();
                    //this.visInnsporsmalListe = true;
                    console.log("Ferdig med post-api/innsporsmal");
                },
                error => alert(error),
        );
    };

    registrerInnsporsmal() {
        this.InnsporsmalSkjema.setValue({
            id: "",
            navn: "",
            email: "",
            sporsmal: ""
        });
        //Setter statusen til skjemaet som "uberørt" slik at det ikke blir skrevet ut valederings-feilmeldinger
        this.InnsporsmalSkjema.markAsPristine();
        this.visInnsporsmalListe = false;
        this.InnsporsmalStatus = "RegistrereSporsmal";
        this.visInnsporsmal = true;
        this.visHjem = false;
        this.visFAQ = false;
        this.visFAQListe = false;
    }

    slettInnsporsmal(id: number) {
        this._http.delete("api/innsporsmal/" + id)
            .subscribe(
                () => {
                    this.hentAlleInnsporsmal();
                    console.log("Ferdig med delete-api/innsporsmal");
                },
                error => alert(error),
            );
    };

    endreInnsporsmal(id: number) {
        this._http.get<IInnsporsmal>("api/innsporsmal/" + id)
            .subscribe(
                innsporsmal => {
                    this.InnsporsmalSkjema.patchValue({ id: innsporsmal.id });
                    this.InnsporsmalSkjema.patchValue({ navn: innsporsmal.navn });
                    this.InnsporsmalSkjema.patchValue({ email: innsporsmal.email });
                    this.InnsporsmalSkjema.patchValue({ sporsmal: innsporsmal.sporsmal });
                    console.log("Ferdig med get-api/innsporsmal");
                },
                error => alert(error),
            );
        this.InnsporsmalStatus = "Endre";
        this.visInnsporsmal = true;
        this.visInnsporsmalListe = false;
        this.visHjem = false;
        this.visFAQ = false;
        this.visFAQListe = false;
    }

    endreEtInnsporsmal() {
        const endretInnsporsmal = new InnSporsmal();

        endretInnsporsmal.sporsmal = this.InnsporsmalSkjema.value.sporsmal;

        const body: string = JSON.stringify(endretInnsporsmal);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.put("api/innsporsmal/" + this.InnsporsmalSkjema.value.id, body, { headers: headers })
            .subscribe(
                () => {
                    this.hentAlleInnsporsmal();
                    this.visInnsporsmal = false;
                    this.visInnsporsmalListe = true;
                    this.visHjem = false;
                    this.visFAQ = false;
                    this.visFAQListe = false;
                    console.log("Ferdig med post-api/innsporsmal");
                },
                error => alert(error)
            );
    }

    //Metoder for FAQ
    hentAlleFAQ() {
        this._http.get<IFAQ[]>("api/faq/")
            .subscribe(
                FAQene => {
                    this.alleFAQ = FAQene;
                    this.laster = false;
                    console.log("Ferdig med post-api/faq");
                },
                error => alert(error),
            );
    };

    registrerFAQ() {
        this.FAQSkjema.setValue({
            id: "",
            kategori: "",
            sporsmal: "",
            svar: ""
        });

        //Setter statusen til skjemaet som "uberørt" slik at det ikke blir skrevet ut valederings-feilmeldinger
        this.FAQSkjema.markAsPristine();
        this.visFAQ = false;
        this.FAQStatus = "Registrer";
        this.visFAQ = true;
    }

    tilbakeTilFAQ() {
        this.visFAQListe = false;
        this.visFAQ = true;
        this.visHjem = false;
        this.visInnsporsmal = false;
        this.visInnsporsmalListe = false;
    }

    tilbakeTilFAQListe() {
        this.visFAQListe = true;
        this.visFAQ = false;
        this.visHjem = false;
        this.visInnsporsmal = false;
        this.visInnsporsmalListe = false;
    }

    lagreFAQ() {
        var lagretFAQ = new FAQ();

        lagretFAQ.kategori = this.FAQSkjema.value.kategori;
        lagretFAQ.sporsmal = this.FAQSkjema.value.sporsmal;
        lagretFAQ.svar = this.FAQSkjema.value.svar;

        const body: string = JSON.stringify(lagretFAQ);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.post("api/faq", body, { headers: headers })
            .subscribe(
                () => {
                    this.registrerFAQ();
                    this.visFAQListe = true;
                    console.log("Ferdig med post-api/faq");
                },
                error => alert(error),
            );
    };

    slettFAQ(id: number) {
        this._http.delete("api/faq/" + id)
            .subscribe(
                () => {
                    this.hentAlleFAQ();
                    console.log("Ferdig med delete-api/faq");
                },
                error => alert(error),
            );
    };

    endreFAQ(id: number) {
        this._http.get<IFAQ>("api/faq/" + id)
            .subscribe(
                faq => {
                    this.FAQSkjema.patchValue({ id: faq.id });
                    this.FAQSkjema.patchValue({ kategori: faq.kategori });
                    this.FAQSkjema.patchValue({ sporsmal: faq.sporsmal });
                    this.FAQSkjema.patchValue({ svar: faq.svar });
                    console.log("Ferdig med get-api/faq");
                },
                error => alert(error),
            );
        this.FAQStatus = "Endre";
        this.visFAQ = true;
        this.visFAQListe = false;
    }

    endreEnFAQ() {
        const endretFAQ = new FAQ();

        endretFAQ.sporsmal = this.FAQSkjema.value.sporsmal;
        endretFAQ.svar = this.FAQSkjema.value.svar;

        const body: string = JSON.stringify(endretFAQ);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.put("api/faq/" + this.FAQSkjema.value.id, body, { headers: headers })
            .subscribe(
                () => {
                    this.hentAlleFAQ();
                    this.visFAQ = false;
                    this.visFAQListe = true;
                    this.visInnsporsmalListe = false;
                    this.visInnsporsmal = false;
                    this.visHjem = false;
                    console.log("Ferdig med post-api/faq");
                },
                error => alert(error)
            );
    }

    //Metoder for navbar
    isExpanded = false;

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }
}
