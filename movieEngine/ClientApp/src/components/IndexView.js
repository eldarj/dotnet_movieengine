import React, { Component } from 'react';
import './IndexView.css';

export class IndexView extends Component {
    static displayName = IndexView.name;

    defaultFilterType = 'Movie';
    apiHeaders = new Headers({ 'Authorization': 'Basic ' + btoa('eja:eja') });
    subtitleMap = { 'Movie': 'Top rated Movies', 'TV Show': 'Top rated TV Shows' };

    titles = [];

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

    getFilteredTitles(type, query = '') {
        if(query === '') return this.titles.filter(itm => itm.type === type);
        return this.titles.filter(itm => {
            let toFilter = itm.name;
            return itm.type === type && toFilter.toLowerCase().includes(query.toLowerCase());
        });
    }

    renderByType(typeName = this.defaultFilterType) {
        let _sub = typeof this.subtitleMap[typeName] === 'undefined' ? typeName :
            this.subtitleMap[typeName];

        this.setState({
            items: this.getFilteredTitles(typeName),
            subtitle: _sub,
            selectedTypeName: typeName,
        });
    }

    handleSearchOnChange(e) {
        let query = e.target.value;
        if (query.length === 0) this.setState({ items: this.getFilteredTitles(this.state.selectedTypeName) });

        if (query.length < 2) return;

        this.setState({ items: this.getFilteredTitles(this.state.selectedTypeName, query) });
    }

    static renderItemsTable(items) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                    <th>Name</th>
                    <th>Released</th>
                    <th>Type</th>
                    </tr>
                </thead>
                <tbody>
                { items.map(itm =>
                    <tr key={itm.id}>
                        <td>{itm.name}</td>
                        <td>{itm.released}</td>
                        <td>{itm.type}</td>
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
                <div className="d-flex flex-row justify-content-between">
                    <ul className="nav nav-tabs">
                        {this.state.types.map(t =>
                            <li className="nav-item d-flex align-items-end" key={t.name}>
                                <a className={"nav-link " + (t.name === this.state.selectedTypeName ? "active" : "")}
                                    onClick={() => this.renderByType(t.name)}>
                                    {t.name}
                                </a>
                            </li>
                        )}
                    </ul>
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
                </div>
                <div>{contents}</div>
            </div>
        );
    }
}
