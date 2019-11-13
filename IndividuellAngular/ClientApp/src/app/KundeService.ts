export class FAQ {
    id: number;
    sporsmal: string;
    svar: string;
    kategori: string;
}

export interface IFAQ {
    id: number;
    sporsmal: string;
    svar: string;
    kategori: string;
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
