import { Component, OnInit,Input,Output } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {
@Input() eText=''
@Input() sText=''
@Input() title=''
@Input() id!:string
// modalLabel=this.id+"Label"
  constructor() { }

  ngOnInit(): void {
  }

}
