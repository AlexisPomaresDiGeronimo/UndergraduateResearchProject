import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiUrlService } from 'src/app/services/apiservice.service';

interface Contact {
  Id : number,
  Firstname : string,
  Lastname : string,
  Email: string ,
  Phone : string ,
  Message : string 
}

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent{
  contacts : Contact[] | undefined;
  constructor(private http: HttpClient, private apiUrlService : ApiUrlService) {}

  ngOnInit() : void{
    this.http.get(this.apiUrlService.getUrl() +'Contact').subscribe(
      (data : any) => {
        this.contacts = data
        console.log(this.contacts)
      }
    )
  };
}
