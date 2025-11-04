Summary
Implement a system that can store or retrieve a list of power plants.
Use best practices and coding standards as you think best.
Functional Requirements
1. A power plant should be defined by the following fields

<img width="593" height="208" alt="image" src="https://github.com/user-attachments/assets/a1cdfc1f-122c-482a-8e1a-a6ba935b0301" />

2. Create a GET API endpoint that retrieves all stored power plants as a JSON response.
Example of an expected response:
Response Example

<img width="449" height="483" alt="image" src="https://github.com/user-attachments/assets/467dfae0-0ca1-40f4-b738-658247a757a0" />

3. Create a POST API endpoint that adds a new power plant to the stored list. Expected
JSON request:
1. Given a required field is missing
When a POST request is submitted
Then a Bad Request (HTTP status code 400) response should be returned by the
API
2. Given power value is less than 0 or greater than 200
When a POST request is submitted
Then a Bad Request (HTTP status code 400) response should be returned by the
API
3. Given &quot;owner&quot; value does not consist of two words (text-only characters)
separated by a whitespace
When a POST request is submitted
Then a Bad Request (HTTP status code 400) response should be returned by the
API
4. Given all power plant data is valid
When a POST request is submitted
Then a Created (HTTP status code 201) response should be returned by the API,
expected response:

<img width="333" height="165" alt="image" src="https://github.com/user-attachments/assets/6f8cd42a-2326-4c3a-82d5-dbebff23fc65" />

4. Filtering support for GET endpoint
1. Given a query parameter &quot;owner&quot; is provided (e.g. &quot;?owner=ona&quot;)
When a GET request is submitted
Then only power plants whose &quot;owner&quot; field contains the specified parameter
value should be returned
Non-Functional Requirements
1. Use the latest stable version of .NET Download .NET (Linux, macOS, and Windows) |
.NET
2. Code should be stored on a git repository reachable by a shared URL, e.g.
https://github.com/
3. Use a relational database for persistence
Bonus Requirements (nice to have)
1. Use EFCore
2. Add a unit test for the validation logic of the POST endpoint

3. Add paging to GET endpoint
4. Improve filtering to work with accented characters, e.g. filter &quot;petraite&quot; should match
&quot;Ona Petraitė&quot;
5. Responses for Bad Request responses (POST endpoint) should include error descriptions
of what went wrong

During the interview we review the completed homework assignment and ask questions / give
feedback about the implementation.
An additional on-the-spot requirement can be added to the assignment during the interview so
the interviewee implements on-the-spot changes.
