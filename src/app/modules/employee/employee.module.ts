import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from './components/button/button.component';
import { ContainerComponent } from './components/container/container.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { EmployeeDetailComponent } from './components/employee-detail/employee-detail.component';
import { ModalComponent } from './components/modal/modal.component';

import { ReactiveFormsModule } from '@angular/forms';
import { EmpFormComponent } from './components/emp-form/emp-form.component';



@NgModule({
  declarations: [
    ButtonComponent,
    ContainerComponent,
    EmployeeListComponent,
    EmployeeDetailComponent,
    ModalComponent,
    EmpFormComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports:[
    ContainerComponent
  ]
})
export class EmployeeModule { }
