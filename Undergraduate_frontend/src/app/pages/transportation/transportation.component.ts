import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ApiUrlService } from 'src/app/services/apiservice.service';

interface Transportation{
  Id          : number,   
  Name        : string ,
  Type        : string ,
  Description : string ,
  Location    : string ,
  Phone       : string ,
  Photo       : string
}
@Component({
  selector: 'app-transportation',
  templateUrl: './transportation.component.html',
  styleUrls: ['./transportation.component.css']
})
export class TransportationComponent {
 constructor(private http : HttpClient, private apiUrlService: ApiUrlService){}
 transportations : Transportation[] | undefined;
  ngOnInit() : void{
    this.http.get(this.apiUrlService.getUrl() +'Transportation').subscribe(
    (data : any) => {
      this.transportations = data
      console.log(this.transportations)
    }
    )
  };
}
