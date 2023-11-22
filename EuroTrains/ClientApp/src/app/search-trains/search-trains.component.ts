import { Component, OnInit } from '@angular/core';
import { Time } from '@angular/common';
import { TrainsService } from './../api/services/trains.service'
import { TrainsRm } from '../api/models';

@Component({
  selector: 'app-search-trains',
  templateUrl: './search-trains.component.html',
  styleUrls: ['./search-trains.component.css']
})
export class SearchTrainsComponent implements OnInit {

  searchResult: TrainsRm[] = []


  constructor(private trainsService: TrainsService) { }

  ngOnInit(): void {
  }

  search() {
    this.trainsService.searchTrains({})
      .subscribe(response => this.searchResult = response,
        this.handleError)
  }

  private handleError(err: any) {
    console.log(err)
  }


}


