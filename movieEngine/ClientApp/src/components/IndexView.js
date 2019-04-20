import React, { Component } from 'react';
import './IndexView.css';

export class IndexView extends Component {
    static displayName = IndexView.name;

    defaultFilterType = 'Movie';
    apiHeaders = new Headers({ 'Authorization': 'Basic ' + btoa('eja:eja') });
    subtitleMap = { 'Movie': 'Top rated Movies', 'TV Show': 'Top rated TV Shows' };

    titles = [];

    inputFieldQuery = '';

    constructor(props) {
        super(props);

        this.state = { items: [], types: [], subtitle: '', selectedTypeName: false, loadingData: true };

        fetch('api/types', {
            headers: this.apiHeaders
        })
        .then(response => response.json())
        .then(data => {
            this.setState({
                types: data
            });
        });

        fetch('api/titles', {
            headers: this.apiHeaders
        })
        .then(response => response.json())
        .then(data => {
            this.titles = data;
            this.setState({
                items: this.getFilteredTitles(this.defaultFilterType),
                subtitle: this.subtitleMap[this.defaultFilterType],
                selectedTypeName: this.defaultFilterType,
                loadingData: false
            });
        });
    }

    //"5 stars", "at least 3 stars", "after 2015", "older than 5 years"
    filterByRegexHelper = {
        phrases:
        {
            minimumRating: /^at least ([0-9]*) stars$/,

            exactRating: /^([0-9]*) stars$/,

            releasedAfterYear: /^after ([0-9]*)$/,

            olderThanYears: /^older than ([0-9]*) years$/,
        },
        filterByRegex: (str, items) => {
            for (var key in this.filterByRegexHelper.phrases) {
                let _reg = this.filterByRegexHelper.phrases[key];
                if (_reg.test(str)) {
                    let _val = str.replace(_reg, '$1');
                    switch (key) {
                        case 'minimumRating':
                            return items.filter(itm => itm.rating >= _val);
                        case 'exactRating':
                            return items.filter(itm => itm.rating == _val);
                        case 'releasedAfterYear':
                            return items.filter(itm => itm.released.split('.')[2] >= _val);
                        case 'olderThanYears':
                            return items.filter(itm => {
                                let _yearDiff = new Date().getYear() - itm.released;
                                if (_yearDiff >= _val) return true;
                                return false;
                            });
                        default: return undefined;
                    }
                }
            }
            return undefined;
        }
    }

    getFilteredTitles(typeName, query = '') {
        let filteredItems = this.titles.filter(itm => itm.type === typeName);

        if (query === '') {
            return filteredItems;
        }

        let filteredItemsByRegex = this.filterByRegexHelper.filterByRegex(query, filteredItems);
        if (typeof filteredItemsByRegex !== 'undefined') {
            filteredItems = filteredItemsByRegex;
        }
        else {
            filteredItems = filteredItems.filter(itm => {
                let _filterBy = itm.name + itm.description;
                return _filterBy.toLowerCase().includes(query.toLowerCase());
            });
        }
       
        return filteredItems;
    }

    handleSearchOnChange(e) {
        this.inputFieldQuery = e.target.value;

        if (this.inputFieldQuery.length === 0) {
            this.setState({ items: this.getFilteredTitles(this.state.selectedTypeName) }); //reload the data with the predefined selected type
        }

        if (this.inputFieldQuery.length < 2) {
            return; //nothing - don't change the data source
        }

        //we filter the items within the getFilteredTitles and set it
        this.setState({ items: this.getFilteredTitles(this.state.selectedTypeName, this.inputFieldQuery) }); 
    }

    handleFilterByType(typeName = this.defaultFilterType) {
        let _sub = typeof this.subtitleMap[typeName] === 'undefined' ? typeName :
            this.subtitleMap[typeName];

        this.setState({
            items: this.getFilteredTitles(typeName, this.inputFieldQuery),
            subtitle: _sub,
            selectedTypeName: typeName,
        });
    }

    static renderItemsTable(items) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                    <th># (Total {items.length})</th>
                    <th>Title</th>
                    <th>Released</th>
                    <th>Rating</th>
                    <th>Type</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map((itm, k) =>
                        <tr key={itm.id} >
                            <td>{++k}</td>
                            <td className="title-name-desc">
                                <div className="font-weight-bold">{itm.name}</div>
                                <div className="small">{itm.description}</div>
                            </td>
                            <td><small>{itm.released}</small></td>
                            <td><small>{itm.rating}</small></td>
                            <td><small>{itm.type}</small></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loadingData ? <p>Loading...</p> : IndexView.renderItemsTable(this.state.items);
        
        return (
            <div className="titles-wrapper">
                <h1>Movie Engine</h1>
                <p>{this.state.subtitle}</p>
                <div className="search-filter mb-2">
                    <small>-- * Use specific search phrases like "5 stars", "at least 3 stars", "after 2015", "older than 5 years"</small>
                    <div className="input-group input-group-sm">
                        <div className="input-group-prepend">
                            <span className="input-group-text" id="basic-addon1">Search</span>
                        </div>
                        <input type="text" className="form-control"
                            onChange={(e) => this.handleSearchOnChange(e)}
                            placeholder="Search by title, desc., release date, rating..." />
                    </div>
                </div>
                <ul className="nav nav-tabs">
                    {this.state.types.map(t =>
                        <li className="nav-item d-flex align-items-end" key={t.name}>
                            <a className={"nav-link " + (t.name === this.state.selectedTypeName ? "active" : "")}
                                onClick={() => this.handleFilterByType(t.name)}>
                                {t.name}
                            </a>
                        </li>
                    )}
                </ul>
                <div>{contents}</div>
            </div>
        );
    }
}
