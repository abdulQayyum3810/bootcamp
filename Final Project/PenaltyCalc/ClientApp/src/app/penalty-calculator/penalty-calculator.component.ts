import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { dataModel } from '../models/dataModel';
import { ManageDataService } from '../services/manage-data.service';
import { Validators } from '@angular/forms';
import { recievedDataModel } from '../models/recievedDataModel';

@Component({
  selector: 'app-penalty-calculator',
  templateUrl: './penalty-calculator.component.html',
  styleUrls: ['./penalty-calculator.component.css']
})
export class PenaltyCalculatorComponent implements OnInit {
countries!:string[];
penalty:recievedDataModel={calculatedPenalty:0,currency:''};
penaltyAvailable:boolean=false;
paneltyForm!:FormGroup;
checkin!:string;
checkout!:string;
countryName!:string;
  constructor(private dataSevice:ManageDataService,private fb:FormBuilder) {}

  ngOnInit() {
    
    
    this.dataSevice.getCountries().subscribe(data=>{this.countries=data})
    this.paneltyForm = this.fb.group({
      checkoutDate : [null, [
        Validators.required
      ]],
      checkinDate : [null, [
        Validators.required,
        
      ]],
      selectedCountry : [null, [
        Validators.required,
        
      ]]
    })
  }
  async submit(){
    const formValues=this.paneltyForm.value;
    if (this.paneltyForm.valid){
      this.checkin=formValues.checkinDate
      this.checkout=formValues.checkoutDate

      if(new Date(this.checkin)> new Date(this.checkout)){
        this.countryName=formValues.selectedCountry
        console.log(formValues.checkoutDate);
        let a:dataModel={Checkout:this.checkout,Checkin:this.checkin,CountryName:this.countryName}
        this.dataSevice.getPenalty(a).subscribe(data=>this.penalty=data)
       
      }
      else{
        this.penaltyAvailable=false;
        setTimeout(function() { alert('Checkout date cant be greater than checkin date'); }, 1);
      }
      
  }
  else{
    alert ("Please provide all required fields")
  }
   

}
}
