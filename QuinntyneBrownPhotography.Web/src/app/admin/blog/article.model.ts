import { Tag } from "./tag.model";

export class Article { 
	public id:any;
    public name: string;
    public abstract: string;
    public PublishedDate: Date;
    public tags: Array<Tag> = [];
}
