import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { FAQ, IFAQ } from "./KundeService";
import { InnSporsmal, IInnsporsmal } from "./KundeService";
import { Kategori, IKategori } from "./KundeService";


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
    alleFAQ: Array<Kategori>;
    FAQSkjema: FormGroup;

    visFAQTree: boolean;

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
        this.visFAQTree = false;
    }

    onSubmit() {
        if (this.InnsporsmalStatus == "RegistrereSporsmal") {
            this.lagreInnsporsmal();
        }
        else if (this.FAQStatus == "RegistrerFAQ") {
            this.lagreFAQ();
        }
        else {
            alert("Feil ved registrering!");
        } 
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

    tilbakeTilFAQTree() {
        this.visFAQTree = true;
        this.visInnsporsmalListe = false;
        this.visInnsporsmal = false;
        this.visHjem = false;
        this.visFAQ = false;
        //this.visFAQListe = false;
    }

    tilbakeTilInnsporsmal() {
        this.hentAlleInnsporsmal();
        this.visInnsporsmalListe = true;
        this.visInnsporsmal = false;
        this.visHjem = false;
        this.visFAQ = false;
        //this.visFAQListe = false;
        this.visFAQTree = false;
    }

    tilbakeTilHjem() {
        this.visInnsporsmalListe = false;
        this.visInnsporsmal = false;
        this.visHjem = true;
        this.visFAQ = false;
        //this.visFAQListe = false;
        this.visFAQTree = false;
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
        //this.visFAQListe = false;
        this.visFAQTree = false;
    }

    //Metoder for FAQ
    hentAlleFAQ() {
        this._http.get<IKategori[]>("api/faq/")
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
            sporsmal: "",
            svar: "",
            kategori: "",
        });

        //Setter statusen til skjemaet som "uberørt" slik at det ikke blir skrevet ut valederings-feilmeldinger
        this.FAQSkjema.markAsPristine();
        this.visFAQ = false;
        this.FAQStatus = "RegistrerFAQ";
        this.visFAQ = true;
        this.visFAQTree = false;
        this.visHjem = false;
    }

    tilbakeTilFAQ() {
        //this.visFAQListe = false;
        this.visFAQ = true;
        this.visHjem = false;
        this.visInnsporsmal = false;
        this.visInnsporsmalListe = false;
        this.visFAQTree = false;
    }

    tilbakeTilFAQListe() {
        this.visFAQListe = true;
        this.visFAQ = false;
        this.visHjem = false;
        this.visInnsporsmal = false;
        this.visInnsporsmalListe = false;
        this.visFAQTree = false;
    }

    lagreFAQ() {
        var lagretFAQ = new FAQ();
        lagretFAQ.sporsmal = this.FAQSkjema.value.sporsmal;
        lagretFAQ.svar = this.FAQSkjema.value.svar;
        lagretFAQ.kategori = this.FAQSkjema.value.kategori;

        const body: string = JSON.stringify(lagretFAQ);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.post("api/faq", body, { headers: headers })
            .subscribe(
                () => {
                    this.registrerFAQ();
                    //this.visFAQListe = true;
                    console.log("Ferdig med post-api/faq");
                },
                error => alert(error),
            );
    };



    //Metoder for upvotes og downvotes
    upvoteUpdate(id: Number) {

        let oppdaterUpvote: FAQ;
        

        for (let i = 0; i < this.alleFAQ.length; i++) {
            for (let j = 0; j < this.alleFAQ[i].alleFAQList[].length)
            if (id === this.alleFAQ[i].alleFAQList[0].id) {
                oppdaterUpvote = this.alleFAQ[i].alleFAQList[];
            }
        }

        oppdaterUpvote.upvote++;


        const body: string = JSON.stringify(oppdaterUpvote);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.put("api/faq/" + id, body, { headers: headers }).subscribe();
    }

    /*console.log(id);
    console.log(this.alleFAQ[1].alleFAQList[0]);
    console.log(this.alleFAQ[i].alleFAQList[0].id);
    */

    downvote(downvote: number) {

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
