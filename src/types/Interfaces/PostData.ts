import CommentData from "./CommentData";

interface postData {
  id: string;
  content: string;
  imageUrl: string;
  privacy: string;
  comment: CommentData;
}
export default postData;
