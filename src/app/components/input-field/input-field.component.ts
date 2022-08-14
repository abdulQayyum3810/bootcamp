import { Component, OnInit, Input,Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-input-field',
  templateUrl: './input-field.component.html',
  styleUrls: ['./input-field.component.css']
})
export class InputFieldComponent implements OnInit {
@Input() inputLabel!:string;
@Input() inputId!:string;

@Output() inputVal= new EventEmitter()

  constructor() { }

  ngOnInit(): void {
  }

  sendInputVal(e:string){
    this.inputVal.emit(e)
  }

}
