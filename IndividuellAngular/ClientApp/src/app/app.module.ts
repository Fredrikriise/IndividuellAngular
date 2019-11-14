import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';

import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { MatTreeModule, MatIconModule } from '@angular/material';
import { MatButtonModule } from '@angular/material/button';
import { FaqComponent } from './faq/faq.component'; 

@NgModule({
    imports: [BrowserModule, HttpClientModule, ReactiveFormsModule, MatTreeModule, MatIconModule, MatButtonModule, RouterModule.forRoot([{ path: '', component: AppComponent, pathMatch: 'full' }, { path: 'faq', component: FaqComponent }])],
    declarations: [AppComponent, FaqComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
