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
  constructor(private http: HttpClient, private apiUrlService : ApiUrlService) {}
  contacts : Contact[] | any;
  ngOnInit(): void{
    let url = this.apiUrlService.getUrl() + 'Contact'
    console.log(url)
    this.http.get(url).subscribe(
      (data : any)=>{
        this.contacts = data
        console.log(this.contacts)
      }
    )
  };

  public saveContact(contact: Contact) {
    console.log(contact);
    this.http.post<Contact>(this.apiUrlService.getUrl() + 'Contact', contact).subscribe(
        (data: Contact) => {
          console.log('Contact saved:', data);
        }     
      );
  }
};
