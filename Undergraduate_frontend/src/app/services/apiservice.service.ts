import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiUrlService {
  getUrl() : any{
    let apiUrl = "https://localhost:44334/api/"
    return apiUrl
  }
}