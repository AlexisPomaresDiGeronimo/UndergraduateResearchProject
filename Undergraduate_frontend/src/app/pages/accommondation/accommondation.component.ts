import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ApiUrlService } from 'src/app/services/apiservice.service';

interface Accommondation {
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
  selector: 'app-accommondation',
  templateUrl: './accommondation.component.html',
  styleUrls: ['./accommondation.component.css']
})
export class AccommondationComponent {
  accommondations : Accommondation[] | undefined;
constructor(private http: HttpClient, private apiUrlService : ApiUrlService) {}
ngOnInit() : void{
  this.http.get(this.apiUrlService.getUrl() +'Accommondation').subscribe(
    (data : any) => {
      this.accommondations = data
      console.log(this.accommondations)
    }
  )
};
}
