export class FAQ {
    id: number;
    sporsmal: string;
    svar: string;
    kategori: string;
    upvote: number;
    downvote: number;
}

export interface IFAQ {
    id: number;
    sporsmal: string;
    svar: string;
    kategori: Kategori;
    upvote: number;
    downvote: number;
}

export class InnSporsmal {
    id: number;
    navn: string;
    email: string;
    sporsmal: string;
}

export interface IInnsporsmal {
    id: number;
    navn: string;
    email: string;
    sporsmal: string;
}

export class Kategori {
    kategoriId: number;
    kategoriNavn: string;
    alleFAQList: FAQ;
}

export interface IKategori {
    kategoriId: number;
    kategoriNavn: string;
    alleFAQList: FAQ;
}
