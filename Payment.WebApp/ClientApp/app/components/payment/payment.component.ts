import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http } from '@angular/http';
import { PatternValidator } from '@angular/forms';

@Component({
    selector: 'payment',
    templateUrl: './payment.component.html'
})
export class PaymentComponent {
    public currentCount = 0;
    public apiURL: string;
    public http: Http;
    public model: PaymentModel;
    public isSubmitted: boolean = false;
   // @ViewChild('paymentForm') this.form
    
    constructor(http: Http, @Inject('API_URL') apiUrl: string) {
        this.apiURL = apiUrl;
        this.http = http;
        this.model = new PaymentModel("", "", "", 0.0, "");
    }

    public newPaymentForm() {
        this.model = new PaymentModel("", "", "", 0.0, "");
    }

    //ngOnInit() {
    //    @ViewChild('paymentForm') this.form;
    //}

    public onClickSubmit(paymentForm: NgForm) {
        console.log(this.model);
        this.http.post(this.apiURL + 'api/payment/', this.model).subscribe(result => {
            console.log(result.status);
            if (result.status == 200) {
                alert("Payment data is successfully submitted to SQL server . Also saved as a text file of your temp path ");
                this.newPaymentForm();
                paymentForm.reset();
            }
            else {
                alert("Something has gone Wrong . Please try to submit again");
            }
        }, error => console.error(error));
    }
}

export class PaymentModel {

    constructor(
        public accountName: string,
        public accountNumber: string,
        public bsb: string,
        public amount: number,
        public reference:string

    ) { }

}