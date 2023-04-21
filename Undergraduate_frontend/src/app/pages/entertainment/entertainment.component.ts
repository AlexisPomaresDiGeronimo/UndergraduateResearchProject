import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ApiUrlService } from 'src/app/services/apiservice.service';

interface Entertainment {
  Id : number ,  
  Title : string,
  Type : string,
  Description : string,
  Location : string,
  Phone : string,
  Opened : boolean ,
  Photo       : string
}
@Component({
  selector: 'app-entertainment',
  templateUrl: './entertainment.component.html',
  styleUrls: ['./entertainment.component.css']
})
export class EntertainmentComponent {
  constructor(private http: HttpClient, private apiUrlService : ApiUrlService){}
  entertainments : Entertainment[] | undefined;

  ngOnInit() : void{
    this.http.get(this.apiUrlService.getUrl() +'Entertainment').subscribe(
      (data : any) => {
        this.entertainments = data
        console.log(this.entertainments)
      }
    )
  };
}
