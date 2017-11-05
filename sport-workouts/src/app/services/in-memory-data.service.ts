import { Injectable } from '@angular/core';
import { Exercise } from "app/models/exercise";
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class InMemoryDataService extends InMemoryDbService{
createDb(){
    return {
      
    };
  }
}
 