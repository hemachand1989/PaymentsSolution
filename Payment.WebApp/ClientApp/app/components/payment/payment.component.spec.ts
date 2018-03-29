/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { assert } from 'chai';
import { PaymentComponent, PaymentModel } from './payment.component';
import { FormsModule, NgForm, NgModel } from '@angular/forms';
import { TestBed, async, ComponentFixture,inject } from '@angular/core/testing';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { By } from '@angular/platform-browser';
import { tick } from '@angular/core/testing';
import { fakeAsync } from '@angular/core/testing';

let component: PaymentComponent;
let fixture: ComponentFixture<PaymentComponent>;

describe('PaymentComponent', () => {

    beforeEach(() => {
        TestBed.configureTestingModule(
            {
                declarations: [PaymentComponent],
                imports: [HttpModule, FormsModule],
                providers: [{ provide: 'API_URL', useValue: 'http://localhost:55931/' }]
            });
        fixture = TestBed.createComponent(PaymentComponent);
        component = fixture.componentInstance;
     });

   
    it('should display a title', async(() => {
        
        const titleText = fixture.nativeElement.querySelector('h1').textContent;
        expect(titleText).toEqual('Payment Form');
    }));

    it('should display form is invalid', async(() => {
        const form = fixture.debugElement.query(By.css('#paymentForm')).nativeElement;
        expect(form.valid).toBe(false);
    }));

    it('should display submit button in disabled mode', async(() => {
        const button = fixture.debugElement.query(By.css('#submitBtn')).nativeElement;
        expect(button.disabled).toBe(true);
    }));

    it('form should reset on click of Reset button', async(() => {
        const submitButton = fixture.debugElement.query(By.css('#submitBtn')).nativeElement;
        submitButton.disabled = false;
        const resetButton = fixture.debugElement.query(By.css('#resetBtn')).nativeElement;
        resetButton.Click();
        expect(submitButton.disabled).toBe(true);
    }));

    
});
