import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ContainerComponent } from './components/container/container.component';
import { InputFieldComponent } from './components/input-field/input-field.component';
import { LabelComponent } from './components/label/label.component';
import { ButtonComponent } from './components/button/button.component';
import { DisplayListComponent } from './components/display-list/display-list.component';
import { AddToListComponent } from './components/add-to-list/add-to-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ContainerComponent,
    InputFieldComponent,
    LabelComponent,
    ButtonComponent,
    DisplayListComponent,
    AddToListComponent,
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
