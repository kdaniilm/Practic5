import { Component, OnInit } from '@angular/core';
import { AppModel } from '../models/app-model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  public appModels!: Array<AppModel>;
  public searchString: string = "";


  private headers: HttpHeaders = new HttpHeaders();
  private params = new HttpParams();


  constructor(private http: HttpClient) {
    this.getFirst();
   }

  ngOnInit(): void {
  }

  private getFunc(isFirst: boolean){
    this.headers.append('Content-Type', 'application/json');
    this.params.set("searchString", this.searchString);
    if(this.searchString.length >= 3){
    this.http.get<Array<AppModel>>(environment.serverPath + "/search", {headers: this.headers, params: {searchString: this.searchString}}).subscribe((res) => {

      if(isFirst === false){
      this.appModels = res;
      }
      else{
        this.appModels = res.slice(0, res.length / 2);
      }
    },
    error => {
      console.log(error);
    });
  }
  }

  public getAppModels(event: KeyboardEvent){
    
    if(event.key === "Backspace")
    {
      this.searchString = this.searchString.slice(0, this.searchString.length - 1);
    }
    else if(event.key != "Control" && event.key != "Shift" && event.key != "Tab" && event.key != "Enter"){
      this.searchString += event.key;
    }
    setTimeout(() => this.getFunc(false), 3000);
    
  }

  public getFirst(){
    this.getFunc(true);
  }
}
