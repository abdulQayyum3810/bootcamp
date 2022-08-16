import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { EmployeeModule } from './modules/employee/employee.module';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ManageEmployeeService } from './modules/employee/services/manage-employee.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    EmployeeModule,
    HttpClientModule
  ],
  providers: [ManageEmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
