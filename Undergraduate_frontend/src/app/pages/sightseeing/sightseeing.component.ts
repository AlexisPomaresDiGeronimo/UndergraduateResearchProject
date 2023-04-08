import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ApiUrlService } from 'src/app/services/apiservice.service';

interface Sightseeing{
   Id          : number,  
   Name        : string,
   Description : string,
   Location    : string
}
@Component({
  selector: 'app-sightseeing',
  templateUrl: './sightseeing.component.html',
  styleUrls: ['./sightseeing.component.css']
})
export class SightseeingComponent {
  constructor(private http: HttpClient, private apiUrlService : ApiUrlService){}
  sightseeings : Sightseeing[] | undefined;
  ngOnInit() : void{
    this.http.get(this.apiUrlService.getUrl() +'Sightseeing').subscribe(
    (data : any) => {
      this.sightseeings = data
      console.log(this.sightseeings)
    }
    )};
}
