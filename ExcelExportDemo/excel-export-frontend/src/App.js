import React from "react";

function App() {
  const downloadExcel = async () => {
    try {
      const response = await fetch(
        "http://localhost:5137/api/export/export-data"
      );
      if (!response.ok) throw new Error("Network response was not ok");

      const blob = await response.blob();
      const url = window.URL.createObjectURL(blob);
      const link = document.createElement("a");
      link.href = url;
      link.download = "data.xlsx";
      document.body.appendChild(link);
      link.click();
      link.remove();
    } catch (error) {
      console.error("Error downloading Excel file:", error);
    }
  };

  return (
    <div className="App">
      <h1>Excel Export Test</h1>
      <button onClick={downloadExcel}>Download Excel</button>
    </div>
  );
}

export default App;
