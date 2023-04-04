import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent{
  myData : any;
  readonly apiUrl = "https://localhost:44334/api/"
  
  constructor(private http: HttpClient) {}

  ngOnInit() : void{
    this.http.get(this.apiUrl+'Contact').subscribe(
      (data : any) => this.myData = data
    )
  };

}
