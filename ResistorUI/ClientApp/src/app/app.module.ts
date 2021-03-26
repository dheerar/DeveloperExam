import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ResistorDataComponent } from './Resistors/components/resistor-data/resistor-data.component';
import { ResistorService } from './Resistors/services/resistor.service';

@NgModule({
  declarations: [
    AppComponent,
    ResistorDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'resistor-data', component: ResistorDataComponent }
    ])
  ],
  providers: [ResistorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
