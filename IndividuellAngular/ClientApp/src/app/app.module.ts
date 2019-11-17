import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { MatBottomSheetModule, MatButtonModule,} from '@angular/material';



@NgModule({
    imports: [BrowserModule, HttpClientModule, ReactiveFormsModule, MatBottomSheetModule, MatButtonModule,],
    declarations: [AppComponent],
    bootstrap: [AppComponent],
})
export class AppModule { }
