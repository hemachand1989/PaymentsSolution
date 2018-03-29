import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
   public payments: Payment[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, @Inject('API_URL') apiUrl: string) {
        http.get(apiUrl + 'api/payment').subscribe(result => {
            console.log(result.status);
            this.payments = result.json() as Payment[];
        }, error => console.error(error));
    }
}

interface Payment {
    accountNumber: string;
    accountName: string;
    amount: number;
    status: string;
    createdDate: Date;
    reference: string,
    bsb:string
}
