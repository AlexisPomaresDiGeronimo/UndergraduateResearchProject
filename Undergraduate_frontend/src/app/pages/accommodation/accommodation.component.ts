import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ApiUrlService } from 'src/app/services/apiservice.service';

interface accommodation {
  Id : number,
  Title : string ,
  Type  : string ,
  Description : string ,
  Location : string , 
  Phone :  string ,
  Opened : boolean ,
  Photo       : string
}

@Component({
  selector: 'app-accommodation',
  templateUrl: './accommodation.component.html',
  styleUrls: ['./accommodation.component.css']
})
export class accommodationComponent {
  accommodations : accommodation[] | undefined;
constructor(private http: HttpClient, private apiUrlService : ApiUrlService) {}
ngOnInit() : void{
  this.http.get(this.apiUrlService.getUrl() +'accommodation').subscribe(
    (data : any) => {
      this.accommodations = data
      console.log(this.accommodations)
    }
  )
};
}
